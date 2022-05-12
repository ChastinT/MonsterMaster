using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Quiz : MonoBehaviour
{
    public Button a_Option, b_Option, c_Option, d_Option;
    public Text text, A, B, C, D;
    string question, correct, a, b, c, d;
    string filename = "quiz.txt";
    int count = 0;

    ScoreScript scoreSystem;
    GameOverScript gameOverManager;
    //bool done = false;


    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = GameObject.Find("ScoreSystem").GetComponent<ScoreScript>();
        gameOverManager = GameObject.Find("GameOverManager").GetComponent<GameOverScript>();
        StreamReader source = new StreamReader(Application.dataPath + "/Minigames/Mental Mania/Assets/Resources/" + filename);
        GetQuestion(source);
        Test(source);


    }

    void GetQuestion(StreamReader source)
    {

        question = source.ReadLine();
        text.text = question;
        correct = source.ReadLine();
        a = source.ReadLine();
        b = source.ReadLine();
        c = source.ReadLine();
        d = source.ReadLine();

        A.text = a;
        B.text = b;
        C.text = c;
        D.text = d;

        count++;
        if(count >= 15)
        {
            source.Close();
            text.text = " Congrats your score is: \n" + scoreSystem.getScore();
            gameOverManager.showPanel();
            //done = true;
        }
    }

    void Test(StreamReader source)
    {

        a_Option.onClick.AddListener(delegate {IsCorrect(a, source); });
        b_Option.onClick.AddListener(delegate {IsCorrect(b, source); });
        c_Option.onClick.AddListener(delegate {IsCorrect(c, source); });
        d_Option.onClick.AddListener(delegate {IsCorrect(d, source); });
        
    }

    void IsCorrect(string selected, StreamReader source)
    {
        Debug.Log(question);
        if(selected == correct)
        {
            scoreSystem.AddPoints();
            text.text = question + "\n Correct\n" + scoreSystem.getScore();
        }
        else
        {
            text.text = question + "\n Incorrect\n" + selected;
        }

        GetQuestion(source);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
