using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    private GameController gameController;
    private bool kill;

    public ParticleSystem nitrous;
    public GameObject player;

    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        kill = false;
        nitrous.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (kill == true)
        {
            StartCoroutine(Nitrous());
            nitrous.Play();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.Boost();
            gameObject.GetComponent<Renderer>().enabled = false;
            kill = true;
        }
    }


    IEnumerator Nitrous()
    {
        yield return new WaitForSeconds(6.0f);
        while (true)
        {
            nitrous.Stop();
            Destroy(gameObject);
            break;
        }
    }

}
