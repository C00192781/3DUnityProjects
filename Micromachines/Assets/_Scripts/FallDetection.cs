using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{


    public GameObject explosion;
    public GameObject player;

    private bool explode = false;

    int explosionTimer = 0;

    public float explosionWait;
    float timer = 0.0f;
    // Use this for initialization
    void Start()
    {
        //checkpoint = new Vector3(0, 7, 0);
        GameVariables.checkpoint = new Vector3(0, 7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5)
        {
            explosionTimer++;

            if (explosionTimer == 1)
            {
                Explode();
            }

            StartCoroutine(PlayerRespawn());
                     
        }
    }

    void Explode()
    {
        Instantiate(explosion, player.transform.position, player.transform.rotation);
        GetComponent<Rigidbody>().isKinematic = true;

    }

    void RespawnPlayer()
    {
     
        transform.position = GameVariables.checkpoint;
        transform.rotation = new Quaternion(GameVariables.rotationX, GameVariables.rotationY, GameVariables.rotationZ, 1);
    }



    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            RespawnPlayer();
            GetComponent<Rigidbody>().isKinematic = false;
            explosionTimer = 0;
            break;
        }
    }
}
