using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    PlayerInfo playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count;i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
               var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero,Quaternion.identity,transform);
               obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0"); 
               itemsDisplayed.Add(inventory.Container[i],obj);
            }
        }
    }

    private void AddEvent(GameObject obj, EventTriggerType type,UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public void CreateDisplay()
    {
        ItemType type;
        for (int i = 0; i < inventory.Container.Count;i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero,Quaternion.identity,transform);

             type = inventory.Container[i].item.type;
             switch(type)
             {
                 case ItemType.Food: 
                    FoodObject item = (FoodObject)inventory.Container[i].item;
                    InventorySlot inventorySlot = inventory.Container[i];
                     AddEvent(obj,EventTriggerType.PointerClick, delegate {testFood(item,inventorySlot);});
                     break;
             }
            //AddEvent(obj,EventTriggerType.PointerClick, delegate {testClick(item);});
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i],obj);
        }
    }

    public void testClick(ItemObject item)
    {
        switch(item.type)
        {
           
            case ItemType.Food: 
                
                Debug.Log("This is food"+item);
                break;
        }
        Debug.Log("Button was clicked");
    }

    public void testFood(FoodObject foodItem, InventorySlot inventorySlot)
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        if (playerInfo.getCurMonster() != null && inventorySlot.amount > 0)
        {
            playerInfo.feedMonster(foodItem.getHungerValue());
            inventorySlot.UseItem();
            Debug.Log("Monster hunger has been increased by "+foodItem.getHungerValue());

        }
    }
}
