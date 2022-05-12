using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverScript : MonoBehaviour
{
    ScoreScript scoreSystem;
    public GameObject gameOverPanel;
    PlayerInfo playerInfo;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = GameObject.Find("ScoreSystem").GetComponent<ScoreScript>();
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void ReloadScene()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BackToHub()
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hub");
       
    }

    public void addScoreToMonster()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BlockBash")
        {
            playerInfo.curMonster.increaseVigor(scoreSystem.getScore());
        }
        else if (scene.name == "ChaoticCollecting")
        {
            playerInfo.curMonster.increaseDexterity(scoreSystem.getScore());
        }
        else if (scene.name == "MentalMania")
        {
            playerInfo.curMonster.increaseIntelligence(scoreSystem.getScore());
        }
        else if (scene.name == "RunningRally")
        {
            playerInfo.curMonster.increaseAgility(scoreSystem.getScore());
        }
        playerInfo.curMonster.decreaseCleanlinessStat(25);
        playerInfo.curMonster.increaseHappinessStat(25);
    }

    public void showPanel()
    {
        addScoreToMonster();
        gameOverPanel.SetActive(true);
        string resultText = "";
        resultText = scoreSystem.score+" Points have been added to ";
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BlockBash")
        {
            resultText += "Vigor";
        }
        else if (scene.name == "ChaoticCollecting")
        {
                resultText += "Dexterity";
        }
        else if (scene.name == "MentalMania")
        {
                resultText += "Intelligence";
        }
        else if (scene.name == "RunningRally")
        {
               resultText += "Agility";
        }
        text.text = resultText;
    }

    
}
