using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = 0f;
    }

    public void SetMana(float mana)
    {
        slider.value = mana;
    }
}
