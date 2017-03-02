using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact2 : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;


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

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }


        //Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag != "Player")
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
        }
    }
}
