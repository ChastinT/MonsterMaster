using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    void Start()
    {

    }
   public void exitgame()
    {
        Debug.Log("Exitting Game");
        Application.Quit();
    }
}
