using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D collider;

    private float width;
    private float scrollSpeed = -3f;
    public float period = 10.0f;
    private float nextActionTime = 10.0f;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();

        width = collider.size.x * 0.3f;
        collider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
        //ResetBound();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < (-width))
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
        if(Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            scrollSpeed -= 0.5f;
            rb.velocity = new Vector2(scrollSpeed, 0);
        }
    }
}
