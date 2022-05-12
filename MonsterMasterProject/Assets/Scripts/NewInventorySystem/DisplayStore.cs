using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayStore : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    PlayerInfo playerInfo;
    public TextMeshProUGUI dialogueText;
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
                 TextMeshProUGUI[] itemTexts = itemsDisplayed[inventory.Container[i]].GetComponentsInChildren<TextMeshProUGUI>();
                 itemTexts[0].text = inventory.Container[i].item.itemName;
                 itemTexts[1].text = "$"+inventory.Container[i].item.price;
                //temsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.itemName;
                //itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.price+"";
            }
            else
            {
               var obj = Instantiate(inventory.Container[i].item.storePrefab, Vector3.zero,Quaternion.identity,transform);
               obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.itemName; 
               obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.price+""; 
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
            var obj = Instantiate(inventory.Container[i].item.storePrefab, Vector3.zero,Quaternion.identity,transform);
            ItemObject item = inventory.Container[i].item;
            AddEvent(obj,EventTriggerType.PointerClick, delegate {buyItem(item);});
            AddEvent(obj,EventTriggerType.PointerEnter, delegate {displayDescription(item);});
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

    public void buyItem(ItemObject item)
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        if (playerInfo.getMoney() >= item.price)
        {
            playerInfo.decreaseMoney(item.price);
            playerInfo.inventory.AddItem(item,1);
            dialogueText.text = "Shwon: Thank you for your patronage.";
        }
        else
        {
           dialogueText.text = "Shwon: Yo, you need more money!";
        }
           
    }

    public void displayDescription(ItemObject item)
    {
        dialogueText.text = "Shwon: "+item.description;
    }
}
