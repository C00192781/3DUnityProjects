using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeuver : MonoBehaviour {

    public Vector2 startWait; // range
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;

    public float horizontal;
    public float smoothing;
    public Boundary boundary;

    private Transform playerTransform;
    private GameController gameController;

    private float targetManeuver;
    // current speed must allows be the same
    private float currentSpeed;
    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //if (playerTransform != null)
        //{
        // playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //}

        StartCoroutine(Evade());
    }

    // Evade by setting a target on the X-Axis
    // Move towards this over a period of time
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            // to keep enemy away from boundaries
            targetManeuver = Random.Range(1, horizontal) * -Mathf.Sign(transform.position.x);
            //if (playerTransform == null)
            //{
            //    return;
            //}

            //targetManeuver = playerTransform.position.x;

            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));

        }
    }


    void FixedUpdate()
    {
        currentSpeed = rb2d.velocity.y;
        // make sure it will move at correct speed
        // MoveTowards(float current, float target, float maxDelta)
        // current value, value to move towards, maximum change
        float newManeuver = Mathf.MoveTowards(rb2d.velocity.x, targetManeuver, Time.deltaTime * smoothing); ///*******
        // current speed must allows be the same
        rb2d.velocity = new Vector2(newManeuver, currentSpeed);

        rb2d.position = new Vector2
        (
            Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax)
        );
    }
}
