using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;
    // Start is called before the first frame update
    void Awake()
    {
     container = transform.Find("container");
     shopItemTemplate = container.Find("shopItemTemplate");  
    }

    private void Start() {
       
       /*Creating Item Buttons
      CreateItemButton(OldItem.ItemType.VigStacker,Item.GetSprite(Item.ItemType.VigStacker), "Vigor Stacker", OldItem.GetCost(Item.ItemType.VigStacker),0,OldItem.GetText(Item.ItemType.VigStacker));
      CreateItemButton(OldItem.ItemType.IntStacker,Item.GetSprite(Item.ItemType.IntStacker), "Intelligence Stacker", OldItem.GetCost(Item.ItemType.IntStacker),1,OldItem.GetText(Item.ItemType.IntStacker));
      CreateItemButton(OldItem.ItemType.AgiStacker,Item.GetSprite(Item.ItemType.AgiStacker), "Agility Stacker", OldItem.GetCost(Item.ItemType.AgiStacker),2,OldItem.GetText(Item.ItemType.AgiStacker));
      CreateItemButton(OldItem.ItemType.DexStacker,Item.GetSprite(Item.ItemType.DexStacker), "Dexterity Stacker", OldItem.GetCost(Item.ItemType.DexStacker),3,OldItem.GetText(Item.ItemType.DexStacker));
     */
    
    
    shopItemTemplate.gameObject.SetActive(false); 

    Hide();
    }

    private void CreateItemButton(OldItem.ItemType itemType,Sprite itemSprite, string itemName, int itemCost, int positionIndex,string itemText)
    {
        Transform shopItemTransform  = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 125f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
        
        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {
            //Clicked on shop item button
            TryBuyItem(itemType);
        };
        
        //Method that will make Shwon say the flavor text for the item
        shopItemTransform.GetComponent<Button_UI>().MouseOverFunc = () => {
            //Clicked on shop item button
            Debug.Log(itemText);
        };
    }

    private void TryBuyItem(OldItem.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    public void Show()
    {
        shopCustomer = GameObject.Find("playerInfo").GetComponent<PlayerInfo>(); 
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
