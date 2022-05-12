using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;

public class GridScript : MonoBehaviour
{
   private static GridScript gridInstance;
   private Scene scene;
    private void Awake()
    {
      DontDestroyOnLoad(this);  

      if (gridInstance == null)
      {
          gridInstance = this;
      }
      else
      {
          Destroy(gameObject);
      }
     
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void setVisible()
    {
        
        scene = SceneManager.GetActiveScene();
              if (scene.name != "Hub")
              {
                foreach (Transform child in transform)
                {
                    if (child.gameObject.GetComponent<MonsterStats>())
                    {
                       child.gameObject.GetComponent<SpriteRenderer>().enabled = false; 
                    }
                    else
                    {
                         child.gameObject.SetActive(false);
                    }
                    
                }
              }
              else
              {
                  foreach (Transform child in transform)
                {
                   if (child.gameObject.GetComponent<MonsterStats>())
                    {
                       child.gameObject.GetComponent<SpriteRenderer>().enabled = true; 
                    }
                    else
                    {
                         child.gameObject.SetActive(true);
                    }
                }
              }
    }

    // Update is called once per frame
    void Update()
    { 
        setVisible();
    }
}
