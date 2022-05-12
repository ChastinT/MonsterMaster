using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonsHandler : MonoBehaviour
{
    public Button [] towerButtons;
    private PlayerInfo playerInfo;


    private void Update()
    {
        unlockButtons();
    }

    public void unlockButtons()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        for (int i = 0;i < towerButtons.Length;i++)
        {
            if (i < playerInfo.getTowerProgress())
            {
                towerButtons[i].interactable = true;
            }
            else
            {
               towerButtons[i].interactable = false; 
            }
        }
    }
}
