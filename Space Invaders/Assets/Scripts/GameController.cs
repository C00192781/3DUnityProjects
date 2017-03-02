using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private int score; // should be private, not public
    public bool gameOver;
    private bool restart;

    private int lives;
    private int damage;

    private DestroyByContact contact;

    void Start()
    {
        score = 0;
        lives = 3;
        damage = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();


        GameObject contactObject = GameObject.FindWithTag("Enemy");
        if (contactObject != null)
        {
            contact = contactObject.GetComponent<DestroyByContact>();
        }
        if (contact == null)
        {
            Debug.Log("Cannot find 'DestroyByContactscript'");
        }

    }

    void Update()
    {
        //Debug.Log(damage);
       // Debug.Log("Damage" + damage + "Lives" + lives);
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

       // Debug.Log(lives);
    }

    


   

    
    

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void DamagePlayer(int playerDamage)
    {
        if (damage < 3)
        {
            damage += playerDamage;
            //Debug.Log("Damage" + damage);
            
        }
    }


    public void DetractLives(int livesDetraction)
    {
        if (damage == 3)
        {
            lives -= livesDetraction;
            damage = 0;
            if (lives == 0)
            {
                gameOver = true;
                //contact.killPlayer(true);
            }
          //  Debug.Log("Lives" + lives);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }



    
}
