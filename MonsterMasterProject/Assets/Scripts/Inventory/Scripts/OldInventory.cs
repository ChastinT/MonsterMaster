using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInventory {

    public event EventHandler OnItemListChanged;

    private List<OldItem> itemList;
    private Action<OldItem> useItemAction;

    public OldInventory(Action<OldItem> useItemAction) {
        this.useItemAction = useItemAction;
        itemList = new List<OldItem>();
    /*
        AddItem(new OldItem { itemType = Item.ItemType.VigStacker, amount = 3 });
        AddItem(new OldItem { itemType = Item.ItemType.IntStacker, amount = 1 });
        AddItem(new OldItem { itemType = Item.ItemType.AgiStacker, amount = 1 });
        */
    }

    public void AddItem(OldItem item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (OldItem inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(OldItem item) {
        if (item.IsStackable()) {
            OldItem itemInInventory = null;
            foreach (OldItem inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(itemInInventory);
            }
        } else {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(OldItem item) {
        useItemAction(item);
    }

    

}
