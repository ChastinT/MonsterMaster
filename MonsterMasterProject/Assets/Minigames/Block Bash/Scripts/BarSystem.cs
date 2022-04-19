using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarSystem : MonoBehaviour
{
    AudioSource audiosource;
    public Image tapBar;
    public float rate;
    private bool active = false;
    public ScoreScript scoreScript;

    //Animation for block
       public Image block;
   public Sprite [] blockImages = new Sprite [5];

    

 
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DelayedStart());
        if (tapBar.fillAmount == 1.0f)
        {
            tapBar.fillAmount = 0.0f;
            scoreScript.AddPoints();
        }
        blockAnim();
    }

    public void increaseBar()
    {
        if (active == true)
        {
            if (tapBar.fillAmount < 1.0f)
            {
                audiosource.PlayOneShot(audiosource.clip, 1);
                tapBar.fillAmount += .10f;
                Debug.Log("The bar is being increased");
            }
        }
    }

    
    void decreaseBar()
    {
        
            if (tapBar.fillAmount > 0.0f && tapBar.fillAmount < 1.0f)
            {
                tapBar.fillAmount -= rate;
            }
    
    }

    void blockAnim()
    {
                if (tapBar.fillAmount <= .2f)
                {
                    block.sprite = blockImages[0];
                }
                else if (tapBar.fillAmount  >.2f &&  tapBar.fillAmount  <= .4f)
                {
                    block.sprite = blockImages[1];
                }
                else if (tapBar.fillAmount  > .4f &&  tapBar.fillAmount  <= .6f)
                {
                    block.sprite = blockImages[2];
                }
                else if (tapBar.fillAmount > .6 &&  tapBar.fillAmount <= .8f)
                {
                    block.sprite = blockImages[3];
                }
                else 
                {
                    block.sprite = blockImages[4];
                }
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3f);
        active = true;
        //decreaseBar();
    }
}

