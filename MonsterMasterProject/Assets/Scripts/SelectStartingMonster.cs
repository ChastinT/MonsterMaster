using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectStartingMonster : MonoBehaviour
{
    public Image [] monsterButtons;
    PlayerInfo playerInfo;

    public Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        displayMonsters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void displayMonsters()
    {
        for (int i = 0; i < 3; i++)
        {
            monsterButtons[i].sprite = playerInfo.monsterParty[i].GetComponent<Image>().sprite;
        }
    }

    public void selectStarter(int i)
    {
        if (i < 3)
        {
         attacker.setMonster(playerInfo.monsterParty[i]);   
        }  
    }
}
