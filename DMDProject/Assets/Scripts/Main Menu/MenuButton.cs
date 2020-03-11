using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{


    public Animator A1;
    private int animState = 0;
    private int maxState = 2;
    private int minState = 1;
    private int buttonsOn = 1;
    private int buttonsOff = 0;
    public CanvasGroup cg1;
    public float timer;
   

    void Start()
    {
        A1 = gameObject.GetComponent<Animator>();
        cg1.alpha = 0f;
        
    }
    void Update()
    {
        if (animState == 2)
        {
            A1.SetInteger("MenuButtons", buttonsOn);
           

        }
        else
        {
            A1.SetInteger("MenuButtons", buttonsOff);
            
        }


       

        if (animState == 1)
        {
            Timer();
            if (timer >= 1.4f)
            {
                cg1.alpha += 1.0f * Time.deltaTime;
            }
            
        }
        else
        {
            timer = 0;
            if (timer == 0)
            {
                cg1.alpha -= 1.0f * Time.deltaTime;
            }
        }
        


    }
    public void Click()
    {
 

        if (animState < maxState)
        {
            animState++;
           
        }

        else
        {
            animState = minState;
        }

        A1.SetInteger("ClickButton", animState);

        
        
    }

    public void Timer()
    {
        timer += 1 * Time.deltaTime;
    }
    
}
