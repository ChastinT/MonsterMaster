using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LifeStatSystem : MonoBehaviour
{

   [SerializeField] private MonsterStats monster;
   [SerializeField] private PlayerInfo playerInfo;
   [SerializeField] private UI_Inventory uiInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setMonster(MonsterStats newMonster)
    {
        this.monster = newMonster;
    }
    
    public MonsterStats getMonster()
    {
        return monster;
    }

    public void cleanMonster()
    {
        if (monster != null)
        {
          this.monster.increaseCleanlinessStat();  
        }
    }

    public void setPlayerInventory()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        uiInventory = GameObject.Find("UI_Inventory").GetComponent<UI_Inventory>();
        //uiInventory.SetInventory(playerInfo.getInventory());
    }
}
