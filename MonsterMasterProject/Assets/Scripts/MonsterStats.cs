using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CodeMonkey.Utils;

public class MonsterStats : MonoBehaviour
{
    public string monsterName;
    public int vigor = 0, intelligence = 0, agility = 0, dexterity = 0;
    private bool evolved;
    private int statCap = 500; //Change it when a monster evolve to 999
    public float happinessStat = 100f,cleanlinessStat = 100f,hungerStat = 100f;
    private PlayerInfo playerInfo;
    private LifeStatSystem sys;
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

    //Methods


    public void setmonsterName(string monsterName)
    {
      this.monsterName = monsterName;
    }

    public string getmonsterName()
    {
      return this.monsterName;
    }

    public void increaseVigor(int increaseAmount)
    {
      this.vigor += increaseAmount;
    }

    public void decreaseVigor(int decreaseAmount)
    {
      this.vigor -= decreaseAmount;
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

    public int getStatCap()
    {
      return this.statCap;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>(); //Gets and sets stats in a viewable form
        sys = GameObject.Find("LifeStatSystem").GetComponent<LifeStatSystem>();
        if (playerInfo.getScene().name == "Hub")
        {
          display = GameObject.Find("DisplayStats").GetComponent<DisplayStats>(); //Gets and sets stats in a viewable form
        }
        InvokeRepeating("decreaseHungerStat", 5f, 2f); //Method, startingTime, repeatTime, all read in seconds so  5f equals 5 seconds
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
    
    
    public void decreaseCleanlinessStat(int decreaseAmount)
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

    void Update()
    {
 
    }
}
