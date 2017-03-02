using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble; // maximum tumble value

    void Start()
    {
        // how fast [Rigidbody] it's rotating     
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

}
