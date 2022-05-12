using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Stacker Object", menuName = "Inventory System/Items/Stacker")]
public class StackerObject : ItemObject
{
    public enum StackerType
    {
        Vigor,
        Intelligence,
        Agility,
        Dexterity,    
    }
    public StackerType stackerType;
    public bool increase;
    public int amount;
    public void Awake()
    {
       type = ItemType.Stacker;
    }


    public int activateStacker()
    {
        
        return amount;
    }
    

    


}
