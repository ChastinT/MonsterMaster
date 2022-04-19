using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public Player player;
    
    public PowerUpScript powerUpScript;
    public SpriteRenderer spriteRenderer;
    public bool shieldIsActive = false;
    public string shieldType;
    bool activateAbility;
    public float jumpForce;

    //For dash
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        shieldAbility();
        if (player.isGrounded() == true)
        {
            activateAbility = false;
        }
    }

    public void activateShield()
    {
        shieldIsActive = true;
        spriteRenderer.sprite = powerUpScript.shieldSprite;
    }

    public void deactivateShield()
    {
        shieldIsActive = false;
        spriteRenderer.sprite = null;
    }

    public void shieldAbility()
    {
        if (Input.GetKey(KeyCode.Space) && activateAbility == false && shieldIsActive == true)
        {
            if (shieldType == "Electric")
            {
                player.rb.velocity = Vector2.up * jumpForce;
            }
            else if (shieldType == "Flame") //Dashs
            {
                
            }
            else if (shieldType == "Water")
            {
                player.rb.velocity = Vector2.down * jumpForce;
            }
            activateAbility = true;
        }
    }
}
