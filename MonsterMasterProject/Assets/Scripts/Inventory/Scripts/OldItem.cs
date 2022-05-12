using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OldItem 
{
    private int cost;
    private String flavorText;

    public enum ItemType {
        VigStacker,
        IntStacker,
        AgiStacker,
        DexStacker,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.VigStacker:        return ItemAssets.Instance.vigorStackerSprite;
        case ItemType.IntStacker: return ItemAssets.Instance.intStackerSprite;
        case ItemType.AgiStacker:   return ItemAssets.Instance.agiStackerSprite;
        case ItemType.DexStacker:         return ItemAssets.Instance.dexStackerSprite;
        }
    }  
    
    
    public static Sprite GetSprite(ItemType getType) {
        switch (getType) {
        default:
        case ItemType.VigStacker:        return ItemAssets.Instance.vigorStackerSprite;
        case ItemType.IntStacker: return ItemAssets.Instance.intStackerSprite;
        case ItemType.AgiStacker:   return ItemAssets.Instance.agiStackerSprite;
        case ItemType.DexStacker:         return ItemAssets.Instance.dexStackerSprite;
        }
    }



    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.VigStacker:     
            case ItemType.IntStacker: 
            case ItemType.AgiStacker:   
            case ItemType.DexStacker:  
                return 100;
        }
    }

    public static String GetText(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.VigStacker:   
                return "This vigor stacker will increase your monsters vigor stat by 10 points"; 
            case ItemType.IntStacker: 
                 return "This intelligence stacker will increase your monsters intelligence stat by 10 points";
            case ItemType.AgiStacker:   
                 return "This agility stacker will increase your monsters agility stat by 10 points";
            case ItemType.DexStacker:  
                 return "This dexterity stacker will increase your monsters dexterity stat by 10 points";
                
        }
    }


    public bool IsStackable() {
        switch (itemType) {
        default:
            case ItemType.VigStacker:        
            case ItemType.IntStacker: 
            case ItemType.AgiStacker:   
            case ItemType.DexStacker:     
            return true;
        }
    }

}
