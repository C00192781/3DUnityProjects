using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    


    public Text lapText;
    //public GUIText restartText;
    //public GUIText gameOverText;

    private float lap; // should be private, not public
    //public bool gameOver;
    //private bool restart;

    public static Vector3 checkpoint;


    public bool boost;

    
   

    void Start()
    {
        lap = 0;

        lapText.text = "Lap: " + lap;
        //gameOver = false;
        //restart = false;
        ////restartText.text = "";
        //gameOverText.text = "";
        //UpdateScore();


        //GameObject contactObject = GameObject.FindWithTag("Enemy");
        //if (contactObject != null)
        //{
        //    contact = contactObject.GetComponent<DestroyByContact>();
        //}
        //if (contact == null)
        //{
        //    Debug.Log("Cannot find 'DestroyByContactscript'");
        //}

    }

    void Update()
    {
        /////////////////////////////////////////////Debug.Log(lap);
        //if (restart == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    }
        //}

       // Debug.Log(boost);
    }

    public void AddLap(float newLapValue)
    {
        lap += newLapValue;
        UpdateLaps();
    }


    void UpdateLaps()
    {
        lapText.text = "Lap: " + lap;
    }

    public void Boost()
    {
        boost = true;
    }

}
