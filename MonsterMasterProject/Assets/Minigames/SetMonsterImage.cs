using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMonsterImage : MonoBehaviour
{
    private PlayerInfo playerInfo;
    //If image is a UI
    public Image currentImage;
    //If image is a sprite
    public SpriteRenderer currentSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        if (currentImage != null && currentSprite == null)
        {
           currentImage.sprite = playerInfo.curMonster.GetComponent<Image>().sprite; 
        }
        else if (currentImage == null && currentSprite != null)
        {
            currentSprite.sprite = playerInfo.curMonster.GetComponent<Image>().sprite; 
        }
        
    }
}
