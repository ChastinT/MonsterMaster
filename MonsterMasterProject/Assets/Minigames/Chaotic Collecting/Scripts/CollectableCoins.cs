using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoins : MonoBehaviour
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
        if (gameObject != null)
      {
            if (other.tag == "Player" || other.tag == "Ball")
            {
                    scoreScript.AddPoints();
                    Destroy(gameObject);
            }
            if (other.tag == "Platform")
            {
                Destroy(gameObject);
            }

        }
    }
}
