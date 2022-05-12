using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapButton : MonoBehaviour
{
    public BarSystem barSys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateTap()
    {
        barSys.increaseBar();
    }

    public void disableTapButton()
    {
        gameObject.SetActive(false);
    }
}
