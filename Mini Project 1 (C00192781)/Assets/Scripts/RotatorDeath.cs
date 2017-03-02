using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotatorDeath : MonoBehaviour
{
    private bool rotate;
    private GameController gameController;

    void Start()
    {
        rotate = false;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.CompareTag("Puddle"))
        {
            StartCoroutine(MoveToPosition(transform, new Vector3(-15.0f, 2.0f, 0.0f), 2.0f));
            rotate = true;
            gameController.DetractLives(1);
        }
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPosition = transform.position;
        var time = 0.0f;
        while (time < 1.0f)
        {
            time += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPosition, position, time);
            yield return null;
        }
    }

   // Update is called every frame
    void Update()
    {

        if (rotate == true)
        {
            //Rotate thet transform of the game object this is attached to by 45 degrees, taking into account the time elapsed since last frame.
            transform.Rotate(new Vector3(0, 0, 190) * Time.deltaTime);
        }
    }
}