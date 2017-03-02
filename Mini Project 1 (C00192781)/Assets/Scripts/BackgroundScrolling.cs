using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeY; // length of the tile

    private Vector3 startPosition;
    private float y = 18.5f;
    private int count = 0;


    void Start()
    {
        startPosition = transform.position;
    }

    void check (float mint)
    {
        if (Mathf.Floor(transform.position.y) >= mint)
        {
            count++;
        }
    }

    void Update()
    {
        // Time we are in the game
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        // will change after tileSizeY has been reached
        
        transform.position = startPosition + Vector3.up * newPosition;
        check(y);
    }
}
