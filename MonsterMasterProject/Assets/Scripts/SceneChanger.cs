using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    //To stop the player from switching to training scenes without a monster set
    private PlayerInfo playerInfo; 
    void Start() 
    {
        Scene check = SceneManager.GetActiveScene();
        if (check.name == "Hub")
        {
          playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();  
        }
    }
    

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchToTraining(string sceneName)
    {
        if (playerInfo.getCurMonster() == null)
        {
           Debug.Log("Monster not set, click on a monster to set it into the system");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }



    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
