using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Stacker,
    Food,
    Default
}
public abstract class ItemObject : ScriptableObject
{
   public GameObject itemPrefab;
   public GameObject storePrefab;
   public ItemType type;
   public string itemName;
   [TextArea(15,20)] 
   public string description;
   public int price;
}
