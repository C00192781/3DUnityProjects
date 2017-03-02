using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLap : MonoBehaviour {

    public int lapCounter;
   
    private GameController gameController;
    //GameObject lapObject = GameObject.FindWithTag("Player");

    // Use this for initialization
    void Start () {
        GameObject contactObject = GameObject.FindWithTag("GameController");

        if (contactObject != null)
        {
            gameController = contactObject.GetComponent<GameController>();
        }
       
        //if (contactObject != null)
        //{
        //    contact = contactObject.GetComponent<DestroyByContact>();
        //}
        //if (contact == null)
        //{
        //    Debug.Log("Cannot find 'DestroyByContactscript'");
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            gameController.AddLap(1.0f);
            //Instantiate(e)
        }



    }
}


//using System.Collections.Generic;
//using UnityEngine;


//public class DestroyByContact : MonoBehaviour
//{

//    public GameObject explosion;
//    public GameObject playerExplosion;

//    public int scoreValue;
//    PlayerController instance;

//    private GameController gameController; // should be private, not public

//    private bool kill;

//    // to work for each instance
//    void Start()
//    {
//        // game object that holds gamecontroller script
//        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
//        if (gameControllerObject != null)
//        {
//            gameController = gameControllerObject.GetComponent<GameController>();
//        }
//        if (gameController == null)
//        {
//            Debug.Log("Cannot find 'GameControllerscript'");
//        }
//        kill = false;
//    }

//    void Update()
//    {
//        // Debug.Log(kill);
//        if (kill == true)
//        {
//            Destroy(gameObject);
//        }
//    }


//    public void killPlayer(bool playerDamage)
//    {
//        if (playerDamage == true)
//        {
//            kill = true;
//        }

//    }



//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Civilian") || other.CompareTag("Police"))
//        {
//            return;
//        }

//        // if we have an explosion
//        if (explosion != null)
//        {
//            Instantiate(explosion, transform.position, transform.rotation);
//        }



//        if (other.CompareTag("Player"))
//        {
//            //instance = GameObject("Player").GetComponent<PlayerController>();
//            //instance.lives--;
//            gameController.DamagePlayer(1);
//            gameController.DetractLives(1);


//            //Destroy(other.gameObject);
//            //if (kill == true)
//            //{
//            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
//            Destroy(other.gameObject);

//            //}
//        }

//        // adds score upon enemy death
//        // don't do it this way below as it's too general to work - not specific instance
//        //GetComponent<GameController>().AddScore(scoreValue);#
//        if (other.tag != "Player" || other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Civilian") || other.CompareTag("Police") || other.CompareTag("Tree"))
//        {
//            gameController.AddScore(scoreValue);
//        }


//        Destroy(gameObject);
//    }
//}