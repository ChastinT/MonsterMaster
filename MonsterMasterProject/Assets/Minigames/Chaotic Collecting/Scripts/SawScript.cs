using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public ScoreScript scoreScript;
    public Player player;
    public ShieldScript shield;
    private float min = 2f;
    private float max = 3f;
    public int speed = 1;
    // Use this for initialization
    void Start()
    {

        min = transform.position.x;
        max = transform.position.x + 18;

    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 10)
        {
            speed = (scoreScript.score / 10) + 1;
            Debug.Log(speed);
        }
        
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);

    }

    //Method to damage the player when this object collides with the player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && shield.shieldIsActive == false)
        {
            //End the game when player is hit
        }
        else if (other.tag == "Player" && shield.shieldIsActive == true)
        {
            shield.deactivateShield();
        }
    }
}
