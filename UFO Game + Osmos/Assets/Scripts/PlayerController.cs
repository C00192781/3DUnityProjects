using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    public Text scoreText;
    public Text winText;
    public int score;

   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        winText.text = "";
        SetScoreText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            ScalePlayer();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
       if(score >=12)
        {
            winText.text = "You Win";
        }
    }

    void ScalePlayer()
    {
        transform.localScale += new Vector3 (0.1f, 0.1f, 0);
    }
}
