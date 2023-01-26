using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 20f;

    public TextMeshProUGUI txt_Score;
    public GameObject[] img_Lives;

    public GameObject gameOverPanel;
    public GameObject youWinPanel;

    int brickCount;

    Rigidbody2D rb;

    //rb.velocity = Vector2.down*10f;



    int score = 0;
    public int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            if (lives == 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;
                lives -= 1;
                img_Lives[lives].SetActive(false);
                rb.gravityScale = 0;
            }
        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score += 10;
            txt_Score.text = score.ToString("0000");
            brickCount -= 1;
            if (brickCount == 0) 
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
                Destroy(gameObject);
            }
        }
        //Debug.Log(collision.gameObject.name);
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
        //Debug.Log("Game Over");
    }
}
