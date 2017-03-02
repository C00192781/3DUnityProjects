using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact2 : MonoBehaviour
{

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
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        // if we have an explosion
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }


        if (other.CompareTag("Enemy") || other.CompareTag("Police") || other.CompareTag("Tree") || other.CompareTag("Bolt"))
        {
            Destroy(gameObject);
        }

        
            gameController.AddScore(10);   
    }
}
