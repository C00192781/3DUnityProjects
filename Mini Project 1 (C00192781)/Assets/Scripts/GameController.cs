using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public float spawnValuesExtra;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GameObject[] trees1;
    public Vector3 treeSpawnValues1;
    public float treeSpawnValues1Extra;
    public int treeCount1;
    public float treeSpawnWait1;

    public GameObject[] trees2;
    public Vector3 treeSpawnValues2;
    public float treeSpawnValues2Extra;
    public int treeCount2;
    public float treeSpawnWait2;

    public GameObject[] puddles;
    public Vector3 puddlesSpawnValues;
    public int puddleCount;
    public float puddleSpawnWait;

    public GameObject[] civilians;
    public Vector3 civilianSpawnValues;
    public float civilianSpawnValueExtra;
    public int civilianCount;
    public float civilianSpawnWait;

    public GameObject[] civilians2;
    public Vector3 civilianSpawnValues2;
    public float civilianSpawnValueExtra2;
    public int civilianCount2;
    public float civilianSpawnWait2;


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
        StartCoroutine(SpawnWaves());
        StartCoroutine(TreeWaves1());
        StartCoroutine(TreeWaves2());
        StartCoroutine(PuddlesWaves());
        StartCoroutine(CivilianWaves1());
        StartCoroutine(CivilianWaves2()); 



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
        Debug.Log("Damage" + damage + "Lives" + lives);
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

       // Debug.Log(lives);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x, spawnValuesExtra), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver == true)
            {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }
        }
    }


    IEnumerator TreeWaves1()
    {
        while (true)
        {
            for (int i = 0; i < treeCount1; i++)
            {
                GameObject tree = trees1[Random.Range(0, trees1.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(treeSpawnValues1.x, treeSpawnValues1Extra), treeSpawnValues1.y, treeSpawnValues1.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(tree, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(treeSpawnWait1);
            }

            
        }
    }

    IEnumerator TreeWaves2()
    {
        while (true)
        {
            for (int i = 0; i < treeCount2; i++)
            {
                GameObject tree = trees2[Random.Range(0, trees2.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(treeSpawnValues2.x, treeSpawnValues2Extra), treeSpawnValues2.y, treeSpawnValues2.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(tree, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(treeSpawnWait2);
            }

            
        }
    }

    IEnumerator PuddlesWaves()
    {
        while (true)
        {
            for (int i = 0; i < puddleCount; i++)
            {
                GameObject puddle = puddles[Random.Range(0, puddles.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-puddlesSpawnValues.x, puddlesSpawnValues.x), puddlesSpawnValues.y, puddlesSpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(puddle, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(puddleSpawnWait);
            }

            if (gameOver == true)
            {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }
        }
    }

    IEnumerator CivilianWaves1()
    {
        while (true)
        {
            for (int i = 0; i < civilianCount; i++)
            {
                //// picks one at random from our list
                //GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                GameObject civilian = civilians[Random.Range(0, civilians.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(civilianSpawnValues.x, civilianSpawnValueExtra), civilianSpawnValues.y, civilianSpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(civilian, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(civilianSpawnWait);
            }

            if (gameOver == true)
            {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }
        }
    }

    IEnumerator CivilianWaves2()
    {
        while (true)
        {
            for (int i = 0; i < civilianCount2; i++)
            {
                //// picks one at random from our list
                GameObject civilian = civilians2[Random.Range(0, civilians2.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(civilianSpawnValues2.x, civilianSpawnValueExtra2), civilianSpawnValues2.y, civilianSpawnValues2.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(civilian, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(civilianSpawnWait2);
            }

            if (gameOver == true)
            {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }
        }
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
        gameOver = true;
        GameOver();
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
            gameOver = true;
            if (lives == 0)
            {
                gameOver = true;
                contact.killPlayer(true);
            }
          //  Debug.Log("Lives" + lives);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }  
}
