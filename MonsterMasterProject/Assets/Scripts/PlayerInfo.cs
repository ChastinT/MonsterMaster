using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] public MonsterStats curMonster;
    public MonsterStats [] monsterParty;
    public MonsterStats[] prefabs;
    public InventoryObject inventory;
    private Scene scene;
    private static PlayerInfo playerInstance;
    public int money = 0;
    //public SaveSystem saveSystem;
    private int towerProgress = 1;


    //For item use

    private void Awake()
    {
      DontDestroyOnLoad(this);  

      if (playerInstance == null)
      {
          playerInstance = this;
      }
      else
      {
          Destroy(gameObject);
      }
    }
    private void Start() 
    {
        scene = SceneManager.GetActiveScene();
        curMonster = null; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }
    }

    public Scene getScene()
    {
        return scene;
    }

    public void setCurMonster(MonsterStats curMonster)
    {
     this.curMonster = curMonster;
    }
    public MonsterStats getCurMonster()
    {
        return curMonster;
    }
    
     public void cleanMonster()
    {
        this.curMonster.increaseCleanlinessStat();
    }

    public void increaseMonsterStat()
    {
        curMonster.increaseAgility(10);
    }

    public void feedMonster(float fillAmount)
    {
        curMonster.increaseHungerStat(fillAmount);
    }

    public void setMoney(int money)
    {
        this.money = money;
    }

    public int getMoney()
    {
        return this.money;
    }

    public void increaseMoney(int amount)
    {
        this.money += amount;
    }

     public void decreaseMoney(int amount)
    {
        this.money -= amount;
    }

    public void healMonsters()
    {
        for (int i = 0; i < 3;i++)
        {
            monsterParty[i].currentHealth = monsterParty[i].maxHealth;
        }
    }

    public MonsterStats[] getMonsterParty()
    {
        return monsterParty;
    }

    public int getTowerProgress()
    {
        return towerProgress;
    }

    public void increaseTowerProgress()
    {
        this.towerProgress += 1;
    }

    private void setTowerProgress(int towerProgress)
    {
        this.towerProgress = towerProgress;
    }

    public void useStacker(StackerObject stacker)
    {
        switch (stacker.stackerType)
        {
            case StackerObject.StackerType.Vigor:
                if (stacker.increase == true)
                {
                    curMonster.increaseVigor(stacker.activateStacker());
                }
                else
                {
                    curMonster.decreaseVigor(stacker.activateStacker());
                }
                break;
            case StackerObject.StackerType.Intelligence:
                if (stacker.increase == true)
                {
                    curMonster.increaseIntelligence(stacker.activateStacker());
                }
                else
                {
                    curMonster.decreaseIntelligence(stacker.activateStacker());
                }
                break;
            case StackerObject.StackerType.Agility:
                if (stacker.increase == true)
                {
                    curMonster.increaseAgility(stacker.activateStacker());
                }
                else
                {
                    curMonster.decreaseAgility(stacker.activateStacker());
                }
                break;
            case StackerObject.StackerType.Dexterity:
                if (stacker.increase == true)
                {
                    curMonster.increaseDexterity(stacker.activateStacker());
                }
                else
                {
                    curMonster.decreaseDexterity(stacker.activateStacker());
                }
                break;
            
        }
    }

    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(playerInstance);
    }

    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        int numMon = data.numMonster;
        setMoney(data.money);
        setTowerProgress(data.towerProgress);
        MonsterStats newMonster = null;
        for (int i = 0; i < numMon; i++)
        {
                switch (data.species[i])
                {
                    case "Anjunny":
                        newMonster = (MonsterStats)Instantiate(prefabs[0]);
                        break;
                    case "Anjunny_Ascended":
                        newMonster = (MonsterStats)Instantiate(prefabs[1]);
                        break;
                    case "Burnett":
                        newMonster = (MonsterStats)Instantiate(prefabs[2]);
                        break;
                    case "Faust":
                        newMonster = (MonsterStats)Instantiate(prefabs[3]);
                        break;
                    case "Seraphi":
                        newMonster = (MonsterStats)Instantiate(prefabs[4]);
                        break;
                    case "Ceyt":
                        newMonster = (MonsterStats)Instantiate(prefabs[5]);
                        break;
                    case "Catra":
                        newMonster = (MonsterStats)Instantiate(prefabs[6]);
                        break;
                    case "Blayct":
                        newMonster = (MonsterStats)Instantiate(prefabs[7]);
                        break;
                    case "N01S3":
                        newMonster = (MonsterStats)Instantiate(prefabs[8]);
                        break;
                    case "B'alam":
                        newMonster = (MonsterStats)Instantiate(prefabs[9]);
                        break;
                    case "Voikkid":
                        newMonster = (MonsterStats)Instantiate(prefabs[10]);
                        break;
                    case "Worshepperd":
                        newMonster = (MonsterStats)Instantiate(prefabs[11]);
                        break;
                    case "Vapour":
                        newMonster = (MonsterStats)Instantiate(prefabs[12]);
                        break;
                    case "Jestar":
                        newMonster = (MonsterStats)Instantiate(prefabs[13]);
                        break;
                    case "Inakis":
                        newMonster = (MonsterStats)Instantiate(prefabs[14]);
                        break;
                }
            newMonster.transform.position = this.monsterParty[i].transform.position;
            newMonster.transform.rotation = this.monsterParty[i].transform.rotation;
            newMonster.transform.parent = this.monsterParty[i].transform.parent;

            newMonster.setMonsterName(data.monsters[i]);
            newMonster.setMonsterSpecies(data.species[i]);
            newMonster.increaseVigor(data.allStrength[i]);
            newMonster.increaseIntelligence(data.allIntell[i]);
            newMonster.increaseDexterity(data.allDext[i]);
            newMonster.increaseAgility(data.allAgile[i]);
            newMonster.increaseHappinessStat(data.allHappy[i]);
            newMonster.increaseCleanlinessStat(data.allClean[i]);
            newMonster.increaseHungerStat(data.allHunger[i]);
            newMonster.setMaxHealth(data.maxHealth[i]);
            newMonster.setCurHealth(data.curHealth[i]);
            newMonster.setStatCap(data.statCap[i]);
            Destroy(this.monsterParty[i].gameObject);
            this.monsterParty[i] = newMonster;
        }

    }

}
