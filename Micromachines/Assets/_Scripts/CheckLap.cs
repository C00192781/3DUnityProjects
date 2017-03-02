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