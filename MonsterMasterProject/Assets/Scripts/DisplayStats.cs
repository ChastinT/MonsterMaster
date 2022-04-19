using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public GameObject panel;
    //LifeStats
   public Image happinessIcon;
   public Sprite [] happinessImages = new Sprite [5];
   public Image cleanIcon;
   public Sprite [] cleanImages = new Sprite[5];
   public Image hungerIcon;
   public Sprite [] hungerImages = new Sprite[5];
   public TMP_Text happinessText,cleanlinessText,hungerText;
   private MonsterStats monster;

   //Is used to detect if the display is active or not
   private bool isActive = false;

   //BattleStats
   public TMP_Text vigorValueText,intelValueText,agilityValueText,dexValueText;
   public Slider vigorSlider, intelSlider,agilitySlider,dexSlider;

   //Monster Name and Image
   public Image monsterImage;
   public TMP_Text monsterName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

 // Update is called once per frame
    void Update()
    {
        if (monster != null)
        {
           setStats();   
        }
                 
    }
    
    /*sets a monsters stats*/
    void setStats()
    {
        happinessText.text = this.monster.getHappinessStat()+"%";
        cleanlinessText.text = this.monster.getCleanlinessStat()+"%";
        hungerText.text = this.monster.getHungerStat()+"%";
        setMonsterNameImage();
        setHappyIcon();
        setCleanIcon();
        setHungerIcon();
        setBars();
    }
    public void setMonster(MonsterStats newMonster)
    {
        Debug.Log("I work");
        this.monster = newMonster;
    }

    void setHappyIcon()
    {
        if (monster.getHappinessStat() >= 80)
        {
            happinessIcon.sprite = happinessImages[0];
        }
        else if (monster.getHappinessStat() < 80 &&  monster.getHappinessStat() >= 60)
        {
            happinessIcon.sprite = happinessImages[1];
        }
         else if (monster.getHappinessStat() < 60 &&  monster.getHappinessStat() >= 40)
        {
            happinessIcon.sprite = happinessImages[2];
        }
        else if (monster.getHappinessStat() < 40 &&  monster.getHappinessStat() >= 20)
        {
            happinessIcon.sprite = happinessImages[3];
        }
        else 
        {
            happinessIcon.sprite = happinessImages[4];
        }
    }

    void setCleanIcon()
    {
        if (monster.getCleanlinessStat() >= 80)
                {
                    cleanIcon.sprite = cleanImages[0];
                }
                else if (monster.getCleanlinessStat()  < 80 &&  monster.getCleanlinessStat()  >= 60)
                {
                    cleanIcon.sprite = cleanImages[1];
                }
                else if (monster.getCleanlinessStat()  < 60 &&  monster.getCleanlinessStat()  >= 40)
                {
                    cleanIcon.sprite = cleanImages[2];
                }
                else if (monster.getCleanlinessStat() < 40 &&  monster.getCleanlinessStat() >= 20)
                {
                    cleanIcon.sprite = cleanImages[3];
                }
                else 
                {
                    cleanIcon.sprite = cleanImages[4];
                }
    }

    void setHungerIcon()
    {
        if (monster.getHungerStat()>= 80)
        {
            hungerIcon.sprite = hungerImages[0];
        }
        else if (monster.getHungerStat()< 80 &&  monster.getHungerStat()>= 60)
        {
            hungerIcon.sprite = hungerImages[1];
        }
         else if (monster.getHungerStat()< 60 &&  monster.getHungerStat()>= 40)
        {
            hungerIcon.sprite = hungerImages[2];
        }
        else if (monster.getHungerStat()< 40 &&  monster.getHungerStat()>= 20)
        {
            hungerIcon.sprite = hungerImages[3];
        }
        else 
        {
            hungerIcon.sprite = hungerImages[4];
        }
    }

    void setBars()
    {
       setStatText();
       setSliders();
    }

    void setStatText()
    {
        this.vigorValueText.text = ""+monster.getVigor();
        this.intelValueText.text = ""+monster.getIntelligence();
        this.agilityValueText.text = ""+monster.getAgility();
        this.dexValueText.text = ""+monster.getDexterity();
    }

    void setSliders()
    {
        vigorSlider.maxValue = monster.getStatCap();
        vigorSlider.value = monster.getVigor();
        intelSlider.maxValue = monster.getStatCap();
        intelSlider.value = monster.getIntelligence();
        agilitySlider.maxValue = monster.getStatCap();
        agilitySlider.value = monster.getAgility();
        dexSlider.maxValue = monster.getStatCap();
        dexSlider.value = monster.getDexterity();
    }

    public MonsterStats getMonster()
    {
        return monster;
    }

    public void setMonsterNameImage()
    {
            monsterImage.sprite =  monster.GetComponent<Image>().sprite;
            monsterName.text = monster.getmonsterName();
    }

    public void activatePanel()
    {
        panel.SetActive(true);
        isActive = true;
    }

      public void deactivatePanel()
    {
        panel.SetActive(false);
        isActive = false;
    }

    public bool getIsActive()
    {
        return isActive;
    }
}
