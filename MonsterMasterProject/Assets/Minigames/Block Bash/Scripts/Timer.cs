using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public float timeHolder;
    private bool timerIsRunning = false;
    private bool trueTimeOut = false;
    public GameOverScript gameOverScript;
    public TapButton tapButton;

    public TMP_Text  timeText;

    private void Start()
    {
        //Input timeRemaining in seconds, ex. An input of 120 will give 2 minutes
        Debug.Log(timeHolder);
        timerIsRunning = true;
        StartCoroutine(StartGameCountdownText());
    }
    void Update()
    {
        if (timerIsRunning)
        {
            DisplayTime(timeRemaining);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            //Change later to call out a person and then draw another card
            else
            {
                if (trueTimeOut == false)
                {
                   Debug.Log("Time has run out");
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.text = "Go"; 
                }
                else
                {
                 Debug.Log("Time has truly ended");
                 timeRemaining = 0;
                 tapButton.disableTapButton();
                 gameOverScript.showPanel();
                 timerIsRunning = false;
                }
            }
        }

    }

    public void RestartTimer()
    {
        timeRemaining = timeHolder;
        timerIsRunning = true;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = ""+seconds;
    }

    IEnumerator EraseText()
    {
        yield return new WaitForSeconds(3.5f);
        timeText.text = "";
    }

    IEnumerator StartGameCountdownText()
    {
        yield return new WaitForSeconds(3.5f);
        RestartTimer();
        trueTimeOut = true;
    }
}
