using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class MonsterStats : MonoBehaviour
{
    public string monsterName;
    public string monsterSpecies;
    public int vigor = 0, intelligence = 0, agility = 0, dexterity = 0;
    private bool evolved;
    private int statCap = 500; //Change it when a monster evolve to 999
    public float happinessStat = 100f,cleanlinessStat = 100f,hungerStat = 100f;
    public float maxHealth = 50;
    public float currentHealth = 50;
    private PlayerInfo playerInfo;
    private LifeStatSystem sys;
    [SerializeField] private SelectNewMonster deathScreen;
    [SerializeField] private DisplayStats display;

    public enum Element
    {
      Fire,Water,Wind,Lux, Noct ,Void
    }

    public enum Type
    {
      Humanoid,Beast,BeastMan   
    }

    public Element element;
    public Type type;

    //Monster Evolution
    public MonsterStats [] evolutions;
    public bool hasEvolved = false;

    //Methods

    public void Reset()
    {
        this.vigor = 0;
        this.intelligence = 0;
        this.agility = 0;
        this.dexterity = 0;
        this.happinessStat = 0f;
        this.cleanlinessStat = 0f;
        this.hungerStat = 0f;
    }

    public void setMonsterName(string monsterName)
    {
      this.monsterName = monsterName;
    }

    public string getMonsterName()
    {
      return this.monsterName;
    }

    public void setMonsterSpecies(string monsterSpecies)
    {
      this.monsterSpecies = monsterSpecies;
    }

    public string getMonsterSpecies()
    {
      return this.monsterSpecies;
    }

    public void setMaxHealth(float maxHealth)
    {
      this.maxHealth = maxHealth;
    }

    public float getMaxHealth()
    {
      return this.maxHealth;
    }

    public void setCurHealth(float currentHealth)
    {
      this.currentHealth = currentHealth;
    }

    public float getCurHealth()
    {
      return this.currentHealth;
    }

    public void increaseVigor(int increaseAmount)
    {
      this.vigor += increaseAmount;
      if (this.vigor > 50)
      {
        this.setMaxHealth(this.vigor);
        this.setCurHealth(this.vigor);
      }
      
    }

    public void decreaseVigor(int decreaseAmount)
    {
      this.vigor -= decreaseAmount;
      if (this.vigor < 50)
      {
        this.setMaxHealth(50);
        this.setCurHealth(50);
      }
       
    }

     public int getVigor()
    {
      return this.vigor;
    }

      public void increaseIntelligence(int increaseAmount)
    {
      this.intelligence += increaseAmount;
    }

    public void decreaseIntelligence(int decreaseAmount)
    {
      this.intelligence -= decreaseAmount;
    }

     public int getIntelligence()
    {
      return this.intelligence;
    }

    public void increaseAgility(int increaseAmount)
    {
      this.agility += increaseAmount;
    }

    public void decreaseAgility(int decreaseAmount)
    {
      this.agility -= decreaseAmount;
    }

     public int getAgility()
    {
      return this.agility;
    }

    public void increaseDexterity(int increaseAmount)
    {
      this.dexterity += increaseAmount;
    }

    public void decreaseDexterity(int decreaseAmount)
    {
      this.dexterity -= decreaseAmount;
    }

     public int getDexterity()
    {
      return this.dexterity;
    }

    public float getCleanlinessStat()
    {
      return this.cleanlinessStat;
    }

    public float getHungerStat()
    {
      return this.hungerStat;
    }

    public float getHappinessStat()
    {
      return this.happinessStat;
    }

    public void setStatCap(int cap)
    {
        this.statCap = cap;
    }

    public int getStatCap()
    {
      return this.statCap;
    }

    //Battle Stat Methods
    
    public float getBattleVigor()
    {
      return (this.vigor * (this.hungerStat/100));
    }

    public float getBattleIntelligence()
    {
      return (this.intelligence * (this.happinessStat/100));
    }

     public float getBattleAgility()
    {
      return (this.agility * (this.hungerStat/100));
    }

    public float getBattleDexterity()
    {
      return (this.agility * (this.cleanlinessStat/100));
    }

    // Start is called before the first frame update
    void Start()
    {
      maxHealth = 100 + vigor;
      currentHealth = maxHealth;
      playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>(); //Gets and sets stats in a viewable form
       
        if (playerInfo.getScene().name == "Hub")
        { 
          sys = GameObject.Find("LifeStatSystem").GetComponent<LifeStatSystem>();
          display = GameObject.Find("DisplayStats").GetComponent<DisplayStats>(); //Gets and sets stats in a viewable form
          deathScreen = GameObject.Find("DeathScreen").GetComponent<SelectNewMonster>();
          InvokeRepeating("decreaseHungerStat", 60f, 60f); //Method, startingTime, repeatTime, all read in seconds so  5f equals 5 seconds
          InvokeRepeating("death", 120f, 120f); //Method, startingTime, repeatTime, all read in seconds so  5f equals 5 seconds //120
        }
    }


    void decreaseHungerStat()
    {
      if (hungerStat > 0)
      {
        hungerStat -= 10f;
      }
      else
      {
         hungerStat = 0;
      }
    }

    
    //Method that when a player clicks on monster displays its stats on a panel
    public void OnMouseDown() 
    {
      Debug.Log("Sprite Clicked");
      playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
      display = GameObject.Find("DisplayStats").GetComponent<DisplayStats>();
      sys = GameObject.Find("LifeStatSystem").GetComponent<LifeStatSystem>();
      sys.setMonster(this);
      if (this != playerInfo.getCurMonster())
      {
         playerInfo.setCurMonster(this);
        display.setMonster(this); //Gets and sets stats in a viewable form
        display.activatePanel();
      }
      else
      {
         playerInfo.setCurMonster(null);
         display.setMonster(null);
         display.deactivatePanel();
      }
    }
    
    
    public void decreaseCleanlinessStat(float decreaseAmount)
    {
      if (cleanlinessStat > 0)
      {
        cleanlinessStat -= decreaseAmount;
      }
      else
      {
        cleanlinessStat = 0;
      }
    }

    public void increaseCleanlinessStat()
    {
      if (cleanlinessStat < 100)
      {
        cleanlinessStat += 25;
      }
      else
      {
        cleanlinessStat = 100;
      }
    }

    public void increaseCleanlinessStat(float fillAmount)
    {
        if (cleanlinessStat < 100)
        {
            cleanlinessStat += fillAmount;
        }
        else
        {
            cleanlinessStat = 100;
        }
    }

    public void increaseHungerStat(float fillAmount)
    {
      if (hungerStat < 100)
      {
        hungerStat += fillAmount;
      }
      else
      {
        hungerStat = 100;
      }
    }

    public void decreaseHappinessStat(float decreaseAmount)
    {
      if (happinessStat > 0)
      {
        happinessStat -= decreaseAmount;
      }
      else
      {
        happinessStat = 0;
      }
    }

    public void increaseHappinessStat(float increaseAmount)
    {
      if (happinessStat < 100)
      {
        happinessStat += increaseAmount;
      }
      else
      {
        happinessStat = 100;
      }
    }

    public void evolve()
    {
      if (hasEvolved == false)
      {
        Animator anim = this.GetComponent<Animator>();
        Image image = this.GetComponent<Image>();
        if (vigor >= 500 && intelligence <= 500 && dexterity <= 500 && agility <= 500)
        {
          monsterSpecies = evolutions[0].getMonsterSpecies();
          anim.runtimeAnimatorController = evolutions[0].GetComponent<Animator>().runtimeAnimatorController;
          image.sprite = evolutions[0].GetComponent<Image>().sprite;
          statCap = 1000;
          hasEvolved = true;
        }
        else if (intelligence >= 500 && vigor <= 500 && dexterity <= 500 && agility <= 500)
        {
          monsterSpecies = evolutions[1].getMonsterSpecies();
          anim.runtimeAnimatorController = evolutions[1].GetComponent<Animator>().runtimeAnimatorController;
          image.sprite = evolutions[1].GetComponent<Image>().sprite;
          statCap = 1000;
          hasEvolved = true;
        }
        else if (agility >= 500 && intelligence <= 500 && dexterity <= 500 && vigor <= 500)
        {
          monsterSpecies = evolutions[2].getMonsterSpecies();
          anim.runtimeAnimatorController = evolutions[2].GetComponent<Animator>().runtimeAnimatorController;
          image.sprite = evolutions[2].GetComponent<Image>().sprite;
          statCap = 1000;
          hasEvolved = true;
        }
        else if (dexterity >= 500 && intelligence <= 500 && vigor <= 500 && agility <= 500)
        {
          monsterSpecies = evolutions[3].getMonsterSpecies();
          anim.runtimeAnimatorController = evolutions[3].GetComponent<Animator>().runtimeAnimatorController;
          image.sprite = evolutions[3].GetComponent<Image>().sprite;
          statCap = 1000;
          hasEvolved = true;
        }
        else if (vigor >= 500 && intelligence >= 500 && dexterity >= 500 && agility >= 500)
        {
          int choice = Random.Range(0,4);
          monsterSpecies = evolutions[choice].getMonsterSpecies();
          anim.runtimeAnimatorController = evolutions[choice].GetComponent<Animator>().runtimeAnimatorController;
          image.sprite = evolutions[choice].GetComponent<Image>().sprite;
          statCap = 1000;
          hasEvolved = true;
        }
      }
    }

    void death()
    {
      if ((happinessStat + cleanlinessStat + hungerStat) == 0)
      {
        this.gameObject.SetActive(false);
        deathScreen.showPanel();
      }
    }
}
