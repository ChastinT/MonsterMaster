﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class UI_Inventory : MonoBehaviour {

    private static UI_Inventory inventoryInstance;
    private OldInventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField]private Transform itemSlotTemplate;
    private PlayerInfo player;


    
    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        DontDestroyOnLoad(this);  

      if (inventoryInstance == null)
      {
          inventoryInstance = this;
      }
      else
      {
          Destroy(gameObject);
      }
    }

    public void SetPlayer(PlayerInfo player) {
        this.player = player;
    }

    public void SetInventory(OldInventory inventory) {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {
        foreach (Transform child in itemSlotContainer) 
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f;
        /*
        foreach (OldItem item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                // Use item
                inventory.UseItem(item);
                Debug.Log("Item used");
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
                // Drop item
                OldItem duplicateItem = new OldItem { itemType = item.itemType, amount = item.amount };
                inventory.RemoveItem(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1) {
                uiText.SetText(item.amount.ToString());
            } else {
                uiText.SetText("");
            }

            x++;
            if (x >= 10) {
                x = 0;
                y++;
            }
        }
        */
    }


}