using UnityEngine;
using System.Collections;

public class NodeBehaviour : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    Vector2 direction;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        float moveHorizontal = Random.value;
        float moveVertical = Random.value;

        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        //transform.localPosition = new Vector3(moveHorizontal, moveVertical, 1);


    }

    void FixedUpdate()
    {
        //transform.position += direction;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rb.AddForce(movement * speed);
    }


    // Update is called once per frame
    void Update () {

        // transform.position = (new Vector3(Random.value * Random.value, Random.value * Random.value, 1) * Time.deltaTime);
       // transform.position += direction * speed;
        //Vector2 movement = new Vector2(10, 10);
        //rb.AddForce(movement);
    }

        
        

        
    
}
