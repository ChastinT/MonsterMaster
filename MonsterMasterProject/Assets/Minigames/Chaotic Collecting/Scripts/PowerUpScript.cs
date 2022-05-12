using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public Player player;
    public ShieldScript shieldScript;
    public Sprite shieldSprite;
    public string element;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shieldScript.powerUpScript = this;
            shieldScript.activateShield();
            shieldScript.shieldType = element;
            Destroy(gameObject);
        }
        if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
