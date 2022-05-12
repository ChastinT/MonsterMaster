using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForesightButton : MonoBehaviour
{
    public Attacker team;

    public void OnButtonPress()
    {
        team.foresight = true;
    }
}
