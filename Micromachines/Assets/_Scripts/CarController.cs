﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    private GameController gameController;

    public GameObject wheelFL;
    public GameObject wheelFR;
    public GameObject wheelRL;
    public GameObject wheelRR;

    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider RL;
    public WheelCollider RR;

    public float maxTorque;
    public float maxSteer;

    public float horizontalSpeed;
    public float verticalSpeed;

    private float horizontal = 0.0f;
    private float vertical = 0.0f;

    public Vector3 temp;
    public Vector3 temp2;
    public Rigidbody rb;


    void  Start()
    {
        rb = GetComponent<Rigidbody>();
        temp = rb.centerOfMass;
        temp = new Vector3(0.0f, -0.8f, 0.0f);
        rb.centerOfMass = temp;

        // game object that holds gamecontroller script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void Update()
    {

        // MoveCar();
        Debug.Log(gameController.boost);
        
    }



    void FixedUpdate()
    {
        SteerWheels();
        RotateWheels();
        MoveCar();
        if (gameController.boost == true)
        {
            Boost();
        }


    }

    void MoveCar()
    {
        RR.motorTorque = maxTorque * maxTorque * Input.GetAxis("Vertical");
        RL.motorTorque = maxTorque * maxTorque * Input.GetAxis("Vertical");

        FL.steerAngle = maxSteer * Input.GetAxis("Horizontal");
        FR.steerAngle = maxSteer * Input.GetAxis("Horizontal");

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


    }

    void SteerWheels()
    {
        temp2 = wheelFL.transform.localEulerAngles;
        temp2.y = FL.steerAngle;
        wheelFL.transform.localEulerAngles = temp2;

        temp2 = wheelFR.transform.localEulerAngles;
        temp2.y = FR.steerAngle;
        wheelFR.transform.localEulerAngles = temp2;
    }

    void RotateWheels()
    {
        wheelRL.transform.Rotate(RL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheelRR.transform.Rotate(RR.rpm / 60 * 360 * Time.deltaTime, 0, 0);

        wheelFL.transform.Rotate(FL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheelFR.transform.Rotate(FR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }

    void Boost()
    {
        maxTorque = maxTorque + 40000000000000;
    }
}

