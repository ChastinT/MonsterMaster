using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour
{
    public Player player;
    public ShieldScript shield;
    public Sprite[] virusSprites = new Sprite[5];
    public GameOverScript gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        shield = GameObject.Find("Shield").GetComponent<ShieldScript>();
        gameOverPanel = GameObject.Find("GameOverManager").GetComponent<GameOverScript>();
        this.GetComponent<SpriteRenderer>().sprite = virusSprites[Random.Range(0,5)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method to damage the player when this object collides with the player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && shield.shieldIsActive == false)
        {
            Debug.Log("Game Over");
            gameOverPanel.showPanel();
            Time.timeScale = 0;
        }
        else if (other.tag == "Player" && shield.shieldIsActive == true)
        {
            shield.deactivateShield();
            Destroy(gameObject);
        }
        
          if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
