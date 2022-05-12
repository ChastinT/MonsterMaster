using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerOpponent : MonoBehaviour
{
    public Attacker attackingMonster;
    public int difficulty;
    public PlayerInfo opponent;
    public MonsterStats [] monsters;  //An array to hold all monsters used
    public MonsterStats [] monsterList; //List of monsters to choose from
    public bool battleStarted;
    int awardMoney;
    public GameObject selectionCanvas;
    public GameObject battleCanvas;
    public TMP_Text resultText;
    public GameObject resultScreen;
    public bool TowerBattle;

    public int attacker; //Attacker ranges from 0 to 2, and is the index of the monster in battles



    /*
    Monster List:
    monsterList[0] = Anjunny
    monsterList[1] = Anjunny_Ascended
    monsterList[2] = Burnett
    monsterList[3] = Faust
    monsterList[4] = Seraphi
    monsterList[5] = Ceyt
    monsterList[6] = Catra
    monsterList[7] = Blayct
    monsterList[8] = N01S3
    monsterList[9] = B'alam
    monsterList[10] = Voikkid
    monsterList[11] = Worshepperd
    monsterList[12] = Vapour
    monsterList[13] = Jestar
    monsterList[14] = Inakis
    monsterList[15] = ???



    */
    //
    // Start is called before the first frame update
    void Start()
    {
        opponent = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (battleStarted == true)
        {
          checkWinCondition();   
        }
    }


    void checkWinCondition()
    {
         if (monsters[0].getCurHealth() + monsters[1].getCurHealth() + monsters[2].getCurHealth() > 0 && opponent.monsterParty[0].getCurHealth() + opponent.monsterParty[1].getCurHealth() + opponent.monsterParty[2].getCurHealth() > 0)
        {
            if (attackingMonster.currentMonster.getCurHealth() <= 0)
            {
                if (monsters[0].getCurHealth() > 0)
                {
                    Swap(attackingMonster,0,false);
                }
                else if (monsters[1].getCurHealth() > 0)
                {
                    Swap(attackingMonster,1,false);
                }
                else if (monsters[2].getCurHealth() > 0)
                {
                    Swap(attackingMonster,2,false);
                }
            }

            if (attackingMonster.opponent.currentMonster.getCurHealth() <= 0)
            {
                if (opponent.monsterParty[0].getCurHealth() > 0)
                {
                    Swap(attackingMonster.opponent,0,true);
                }
                else if (opponent.monsterParty[1].getCurHealth() > 0)
                {
                    Swap(attackingMonster.opponent,1,true);
                }
                else
                {
                    Swap(attackingMonster.opponent,2,true);
                }
            }
        }
        else if (opponent.monsterParty[0].getCurHealth() + opponent.monsterParty[1].getCurHealth() + opponent.monsterParty[2].getCurHealth() <= 0)
        {
            Debug.Log("Player Lose");
            playerLose();
        }
        else if (monsters[0].getCurHealth() + monsters[1].getCurHealth() + monsters[2].getCurHealth() <= 0 )
        {
            Debug.Log("Player Win");
           opponent.increaseMoney(awardMoney);
           if (TowerBattle == true && opponent.getTowerProgress() == difficulty)
           {
               opponent.increaseTowerProgress();
           }
            playerWin();
        }
        
    }
    void generateTeam()
    {
        int chooseMonster = 0;
        for (int i = 0;i < 3;i++)
        {
            chooseMonster = Random.Range(0,monsterList.Length);
            monsters[i] = monsterList[chooseMonster];
            switch (difficulty)
            {
                case 1: 
                monsters[i].vigor = Random.Range(1,101);
                monsters[i].intelligence = Random.Range(1,101);
                monsters[i].dexterity = Random.Range(1,101);
                monsters[i].agility = Random.Range(1,101);
                awardMoney = 1000;
                break;

                case 2: 
                monsters[i].vigor = Random.Range(100,501);
                monsters[i].intelligence = Random.Range(1,501);
                monsters[i].dexterity = Random.Range(1,501);
                monsters[i].agility = Random.Range(1,501);
                awardMoney = 5000;
                break;

                case 3: 
                monsters[i].vigor = Random.Range(500,1001);
                monsters[i].intelligence = Random.Range(500,1001);
                monsters[i].dexterity = Random.Range(500,1001);
                monsters[i].agility = Random.Range(500,1001);
                awardMoney = 10000;
                break;
            }
            monsters[i].maxHealth = monsters[i].vigor;
            monsters[i].currentHealth = monsters[i].maxHealth;
            
        }
    }

    public void StartBattle()
    {
        if (difficulty == 1 || difficulty == 2 || difficulty == 3)
        {
           if (attackingMonster.opponent.currentMonster != null)
           {
              if (opponent.monsterParty[0] != null && opponent.monsterParty[1] != null && opponent.monsterParty[2] != null)
              {
               selectionCanvas.gameObject.SetActive(false);
               battleCanvas.gameObject.SetActive(true);
               generateTeam();
               attackingMonster.setMonster(monsters[0]);
               battleStarted = true;    
              }
              
           }
           
        }  
    }

    public void StartTowerBattle()
    {
        if (attackingMonster.opponent.currentMonster != null && difficulty > 0)
           {
               selectionCanvas.gameObject.SetActive(false);
               battleCanvas.gameObject.SetActive(true);
               generateTowerMonsters();
               attackingMonster.setMonster(monsters[0]);
               TowerBattle = true;
               battleStarted = true;
           }
    }

    public void BackToSelection()
    {   
     selectionCanvas.gameObject.SetActive(true);
     battleCanvas.gameObject.SetActive(false);
     difficulty = 0;
     resultScreen.gameObject.SetActive(false);
    }

    void playerLose()
    {
        resultScreen.gameObject.SetActive(true);
        resultText.text = "Player Loses";
        battleStarted = false;
        opponent.healMonsters();
    }

    void playerWin()
    {
        resultScreen.gameObject.SetActive(true);
        resultText.text = "Player Wins";
        battleStarted = false;
        opponent.healMonsters();
    }

    public void Swap(Attacker attacker,int i,bool isPlayer)
    {
        if (isPlayer == false)
        {
             attacker.setMonster(monsters[i]);
            attacker.healthBar.SetMaxHealth(monsters[i].getMaxHealth()); 
            attacker.healthBar.SetHealth(monsters[i].getCurHealth());
        }
        else if (isPlayer == true)
        {
            attacker.setMonster(opponent.monsterParty[i]);
            attacker.healthBar.SetMaxHealth(opponent.monsterParty[i].getMaxHealth()); 
            attacker.healthBar.SetHealth(opponent.monsterParty[i].getCurHealth());
        }   
    }

    public void generateTowerMonsters()
    {
      
            switch(difficulty)
            {
                case 1:
                    monsters[0] = monsterList[0];
                    monsters[1] = monsterList[5];
                    monsters[2] = monsterList[10];
                    break;
                case 2:
                    monsters[0] = monsterList[1];
                    monsters[1] = monsterList[6];
                    monsters[2] = monsterList[11];
                    break;
                case 3:
                    monsters[0] = monsterList[2];
                    monsters[1] = monsterList[7];
                    monsters[2] = monsterList[12];
                    break;
                case 4:
                    monsters[0] = monsterList[3];
                    monsters[1] = monsterList[8];
                    monsters[2] = monsterList[13];
                    break;
                case 5:
                    monsters[0] = monsterList[4];
                    monsters[1] = monsterList[9];
                    monsters[2] = monsterList[14];
                    break;
                case 6:
                    monsters[0] = monsterList[1];
                    monsters[1] = monsterList[2];
                    monsters[2] = monsterList[3];
                    break;
                case 7:
                    monsters[0] = monsterList[2];
                    monsters[1] = monsterList[14];
                    monsters[2] = monsterList[9];
                    break;
                case 8:
                    monsters[0] = monsterList[4];
                    monsters[1] = monsterList[1];
                    monsters[2] = monsterList[6];
                    break;
                case 9:
                    monsters[0] = monsterList[11];
                    monsters[1] = monsterList[11];
                    monsters[2] = monsterList[11];
                    break;
                case 10:
                    monsters[0] = monsterList[15];
                    monsters[1] = monsterList[16];
                    monsters[2] = monsterList[17];
                    break;

            }
        
        for (int i = 0; i < 3;i++)
        {

                monsters[i].vigor = difficulty * 100;
                monsters[i].intelligence = difficulty * 100;
                monsters[i].dexterity = difficulty * 100;
                monsters[i].agility = difficulty * 100;
                awardMoney = 10000 * difficulty;
                monsters[i].maxHealth = monsters[i].vigor * 1.5f;
                monsters[i].currentHealth = monsters[i].maxHealth;
        }
    }

    public void SelectDifficulty(int i)
    {
        difficulty = i;
    }

}

