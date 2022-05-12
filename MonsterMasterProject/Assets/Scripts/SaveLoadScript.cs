using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
    private PlayerInfo playerInfo;
    public void playerSave()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>(); 
        playerInfo.SavePlayer();
    }

    public void playerLoad()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>(); 
        playerInfo.LoadPlayer();
    }
}
