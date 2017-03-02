using UnityEngine;
using System.Collections;

public class SpecialInvader : MonoBehaviour {

	public float minDelayTime = 5.0f;
	public float maxDelayTime = 10.0f;
	public float speed = 5.0f;

	public float startX = -7.5f;
	public float endX = 7.5f;

	bool moving;
	float timer;

	// Use this for initialization
	void Start () {
		WaitToAppear();
	}
	
	// Update is called once per frame
	void Update () {
        // if we're moving
		if (moving)
        {
			transform.position += new Vector3(speed * Time.deltaTime, 0.0f);
            // reset position (left)
			if (transform.position.x > endX)
            {
				WaitToAppear();
			}
		}
        else
        {
            // reduce timer
			timer -= Time.deltaTime;
            // tell to start moving
			if (timer < 0.0f)
            {
				moving = true;
			}
		}
	}

	void WaitToAppear() {
		moving = false;
        // startX - left side of screen (adjustable), 
        // and transform.position.y is the y position where we place him in editor 
		transform.position = new Vector2(startX, transform.position.y);
        // setting timer as random number between the minimum and the maximum
		timer = Random.Range(minDelayTime, maxDelayTime);
	}
}
