using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    // very first frame
    void Start()
    {
        // velocity of it's Z axis * speed 
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
