using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = 0f;
    }

    public void SetAction(float action)
    {
        slider.value = action;
    }
}
