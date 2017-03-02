using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
    void Start()
    {
        float rotateValue = Random.value;
        transform.localScale = new Vector3(rotateValue * 2, rotateValue * 2, 1);
    }

	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
