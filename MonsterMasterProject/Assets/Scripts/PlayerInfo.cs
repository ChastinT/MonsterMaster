using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour, IShopCustomer
{
      [SerializeField] public MonsterStats curMonster;
    //private static Inventory inventory;
    public InventoryObject inventory;
    //[SerializeField] private UI_Inventory uiInventory;
    Scene scene;
    private static PlayerInfo playerInstance;

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
        //inventory = new Inventory(UseItem);
        
        /*
        if (scene.name == "Hub")
        {
             uiInventory.SetInventory(inventory);
        }
        */

        
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

    /*
    private void UseItem(Item item)//Method that allows items to be used
    {
        if (curMonster != null)
        {
            switch (item.itemType)
            {
                case Item.ItemType.VigStacker:
                    Debug.Log(item.ToString()+" removed");
                    curMonster.increaseVigor(10);
                    inventory.RemoveItem(new Item {itemType = Item.ItemType.VigStacker, amount = 1});
                    break;

                 case Item.ItemType.IntStacker:
                    Debug.Log(item.ToString()+" removed");
                    curMonster.increaseIntelligence(10);
                    inventory.RemoveItem(new Item {itemType = Item.ItemType.IntStacker, amount = 1});
                    break;

                case Item.ItemType.AgiStacker:
                    Debug.Log(item.ToString()+" removed");
                    curMonster.increaseAgility(10);
                    inventory.RemoveItem(new Item {itemType = Item.ItemType.AgiStacker, amount = 1});
                    break;
                
                case Item.ItemType.DexStacker:
                    Debug.Log(item.ToString()+" removed");
                    curMonster.increaseDexterity(10);
                    inventory.RemoveItem(new Item {itemType = Item.ItemType.DexStacker, amount = 1});
                    break;
            }  
        }
        else
        {
            Debug.Log("No monster selected");
        }
       
    }
    */
    public void BoughtItem(OldItem.ItemType itemType)//Method that allows items to be bought
    {
        /*
       Debug.Log("Bought item: "+ itemType);
       switch (itemType)
       {
            case Item.ItemType.VigStacker:
                inventory.AddItem(new Item {itemType = Item.ItemType.VigStacker, amount = 1});
                break;

           case Item.ItemType.IntStacker:
                inventory.AddItem(new Item {itemType = Item.ItemType.IntStacker, amount = 1});
                break;

            case Item.ItemType.AgiStacker:
                inventory.AddItem(new Item {itemType = Item.ItemType.AgiStacker, amount = 1});
                break;

            case Item.ItemType.DexStacker:
                inventory.AddItem(new Item {itemType = Item.ItemType.DexStacker, amount = 1});
                break;
       }
       */
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

    /*
    public void setInventory()
    {
        uiInventory.SetInventory(inventory);
    }
    */
    

    /*public Inventory getInventory()
    {
        return inventory;
    }
    */

   /*private void OnApplicationQuit() 
   {
        inventory.Container.Clear();
   }*/
}
