using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMoney : MonoBehaviour
{
    private PlayerInfo playerInfo;
    public TMP_Text moneyDisplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayMoney();
    }
    void displayMoney()
    {
        playerInfo = GameObject.Find("playerInfo").GetComponent<PlayerInfo>();
        moneyDisplayer.text = "$"+playerInfo.getMoney()+"";
    }

}
