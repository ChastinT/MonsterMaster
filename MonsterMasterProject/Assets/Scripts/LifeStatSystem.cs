using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LifeStatSystem : MonoBehaviour
{

   [SerializeField] private MonsterStats monster;
   [SerializeField] private PlayerInfo playerInfo;
   

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
}
