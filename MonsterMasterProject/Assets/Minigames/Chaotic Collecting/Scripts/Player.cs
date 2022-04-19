using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables for player movement
    private float moveInput;
    public float speed;
    public float jumpHeight;


    //Variables to control Jump
    private float jumpTimeCounter;
    public float jumpTime;

    //Player Collision
    private Player player;
    public bool grounded;
    BoxCollider2D boxCollider2D;
    public Rigidbody2D rb;
    [SerializeField] private LayerMask platformsLayerMask;

    //Player Animation
    public int direction = 0;
   



    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        grounded = true;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded() == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeCounter < 0)
            {
                rb.velocity = Vector2.up * jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = 1;
        }

    }


    public bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 1f,platformsLayerMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }


}
