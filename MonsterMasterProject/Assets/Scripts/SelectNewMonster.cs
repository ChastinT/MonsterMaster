using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class SelectNewMonster : MonoBehaviour
{
    public MonsterStats [] prefabs;
    public GameObject panel;
    private PlayerInfo playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectMonster(int i)
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        MonsterStats newMonster = null;
        for (int j = 0; j < playerInfo.monsterParty.Length;j++)
        {
            if (playerInfo.monsterParty[j].gameObject.activeSelf == false)
            {
                switch(i)
                {
                    case 1: //Anjunny
                        newMonster = (MonsterStats)Instantiate(prefabs[0]);
                        break;
                    case 2: //Ceyt
                        newMonster = (MonsterStats)Instantiate(prefabs[1]);
                        break;
                    case 3: //Voikkid
                        newMonster = (MonsterStats)Instantiate(prefabs[2]);
                        break;
                }
                newMonster.transform.position = playerInfo.monsterParty[j].transform.position;
                newMonster.transform.rotation = playerInfo.monsterParty[j].transform.rotation;
                newMonster.transform.parent = playerInfo.monsterParty[j].transform.parent;
                Destroy(playerInfo.monsterParty[j].gameObject);
                playerInfo.monsterParty[j] = newMonster;
                panel.gameObject.SetActive(false);
                break;
            }
        }      
    }

    public void showPanel()
    {
        panel.gameObject.SetActive(true);
    }
}
