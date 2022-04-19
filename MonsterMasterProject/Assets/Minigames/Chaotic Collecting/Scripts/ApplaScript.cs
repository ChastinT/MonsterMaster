using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplaScript : MonoBehaviour
{

    public ScoreScript scoreScript;

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
            scoreScript.AddPoints(); 
       
       }
        //Change to reduce player's health
        else if (other.tag == "Platform")
        {
            Application.Quit();
        }

    }
    
    
}
