using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    private ScoreScript scoreSystem;
    public float period = 10.0f;
    private float nextActionTime = 10.0f;

    private GameOverScript gameOverManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreSystem = GameObject.Find("ScoreSystem").GetComponent<ScoreScript>();
        gameOverManager = GameObject.Find("GameOverManager").GetComponent<GameOverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, moveDirection * moveSpeed);

        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            moveSpeed += 1;
            rb.velocity = new Vector2(0, moveDirection * moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("clear"))
        {
            scoreSystem.AddPoints();
        }
        else if (other.gameObject.CompareTag("boundary"))
        {
            gameOverManager.showPanel();
            Time.timeScale = 0f;
        }
    }
}
