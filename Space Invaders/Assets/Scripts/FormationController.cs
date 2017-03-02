using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {

	public float leftEdge = -5.5f;
	public float rightEdge = 5.5f;

	public float speedX = 0.3f;
	public float speedY = 0.3f;

	public float stepTime = 0.5f;
	public float minStepTime = 0.05f;
	public float stepTimeReduction = 0.9f;
	
	float sinceLastStep = 0.0f;
	bool directionLeft = false;
	bool moveDown = false;

	// Use this for initialization
	void Start () {
		sinceLastStep = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaY = 0.0f;
		float deltaX = 0.0f;

		sinceLastStep += Time.deltaTime;
		if (sinceLastStep > stepTime)
        {
			sinceLastStep -= stepTime;

			// move down
			if (moveDown) {
				moveDown = false;
                // Mathf.Max() returns largest of two or more values
                //using minStepTime to limit this and make sure it doesn't go too fast
                stepTime = Mathf.Max(stepTime * stepTimeReduction, minStepTime);
				deltaY = -speedY;
			}

			// take a step left or right
			if (directionLeft) {
				deltaX = -speedX;
			} else {
				deltaX = speedX;
			}
		}

		transform.position += new Vector3(deltaX, deltaY);	
	}
	
	public void MoveLeft ()
    {
		directionLeft = true;
		moveDown = true;
	}

	public void MoveRight()
    {
		directionLeft = false;
		moveDown = true;
	}
}
