using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Boundary boundary;
    
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector3 position;

    // variables for shooting
    // references to GameObjects
    public GameObject shot; // projectile
    public Transform[] shotSpawns; // ******

    public float fireRate;
    private float nextFire;

    public static int lives;
    public static int health;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        position = transform.position;
    }

    public void PowerUp()
    {
       // shotSpawns[0] 
    }
   
    

    // Why?
    // Not physics related.
    // Don't want to wait for FixedUpdate
    // executes in Update() just before updating the frame, every frame
    void Update()
    {
        // Instantiate shot: object to instantiate to + position
        // Instantiate (object, position, rotation)
        // e.g Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
            }
            GetComponent<AudioSource>().Play();
        }
    }



    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");


        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;


        rb2d.position = new Vector2
        (
            Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax)
        );
    }
}
