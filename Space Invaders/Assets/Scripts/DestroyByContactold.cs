using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactold : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    PlayerController instance;

    private GameController gameController; // should be private, not public

    private bool kill;

    // to work for each instance
    void Start()
    {
        // game object that holds gamecontroller script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameControllerscript'");
        }
        kill = false;
    }

    void Update()
    {
        
    }


    public void killPlayer(bool playerDamage)
    {
        if (playerDamage == true)
        {
            kill = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        // if we have an explosion
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        

        if (other.CompareTag("Shot"))
        {
            //instance = GameObject("Player").GetComponent<PlayerController>();
            //instance.lives--;
            //gameController.DamagePlayer(1);
            //gameController.DetractLives(1);


            //Destroy(other.gameObject);
            //if (kill == true)
            //{
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
            //}


            //if (GetComponent<GameController>().lives <= 0)
            //{
            // Debug.Log(GetComponent<GameController>().lives);
            //    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //    gameController.GameOver();
            //    Destroy(other.gameObject);
            //}





            //if (GetComponent<GameController>().damage >= 0)
            //{
            //    gameController.DetractLives(1);
            //}


            //instance = GameObject("Player").GetComponent<PlayerController>();
            //instance.lives--;
            //if (GetComponent<GameController>().damage < 3)
            //{
            //    gameController.DamagePlayer(1);
            //}

            //if (GetComponent<GameController>().damage >= 3)
            //{
            //    if (GetComponent<GameController>().lives > 0)
            //    {
            //        gameController.DetractLives(1);
            //    }
            //    else if (GetComponent<GameController>().lives <= 0)
            //    {
            //        Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //        gameController.GameOver();
            //    }
            //}



            //GetComponent<PlayerController>().setLives(2);
            ///////PlayerController.lives = -1;
            ////////Debug.Log(PlayerController.lives);
            //Debug.Log(GameObject.Find("Player").GetComponent<PlayerController>().lives);
        }
        // adds score upon enemy death
        // don't do it this way below as it's too general to work - not specific instance
        //GetComponent<GameController>().AddScore(scoreValue);#
        if (other.tag != "Player")
        {
            gameController.AddScore(scoreValue);
        }

        //Destroy(other.gameObject);
        //Destroy(gameObject);
        Destroy(gameObject);
    }
}
