using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}


public class PlayerController : MonoBehaviour {

    // variables for movement
    public float speed;
    public float tilt;
    public Boundary boundary;


    // variables for shooting
    // references to GameObjects
    public GameObject shot; // projectile
    public Transform shotSpawn; // ******

    public float fireRate;
    private float nextFire;

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
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
            GetComponent<AudioSource>().Play();
        }

    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        // constrain ship by setting value of rigidbody's position
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
