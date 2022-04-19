using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class FoodObject : ItemObject
{
    public float restoreHungerValue;
    public void Awake()
    {
       type = ItemType.Food;
    }


    public float getHungerValue()
    {
        return restoreHungerValue;
    }
    

    


}
