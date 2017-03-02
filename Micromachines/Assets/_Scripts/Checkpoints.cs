using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    //static Transform playerTransform;
    //public GameObject player;

    //private Laps lap;

   // private GameVariables variables;

    void Start()
    {
        //playerTransform = GameObject.FindWithTag("Player").transform;
        //player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            GameVariables.checkpoint = transform.position;
            GameVariables.rotationX = transform.rotation.x;
            GameVariables.rotationY = transform.rotation.y -40.0f;
            GameVariables.rotationZ = transform.rotation.z;

        }

        //Is it the Player who enters the collider?
        //if (!other.CompareTag("Player"))
        //{
        //    return; //If it's not the player dont continue
        //}

        //Debug.Log(Laps.currentCheckpoint);

        //if (transform == Laps.checkpoints[Laps.currentCheckpoint].transform)
        //{
        //    //Check so we dont exceed our checkpoint quantity
        //    if (Laps.currentCheckpoint + 1 < Laps.checkpoints.Length)
        //    {
        //        //Add to currentLap if currentCheckpoint is 0
        //        if (Laps.currentCheckpoint == 0)
        //        {

        //            lap.Increase();
        //            //Laps.currentCheckpoint++;
        //        }
        //    }
        //    else
        //    {
        //        //If we dont have any Checkpoints left, go back to 0
        //        lap.Reset();
        //    }
            
        //}


    }

}