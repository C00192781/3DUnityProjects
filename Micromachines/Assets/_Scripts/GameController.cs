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
    }

    void Update()
    {
        
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
