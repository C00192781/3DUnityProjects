using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

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
    }

}