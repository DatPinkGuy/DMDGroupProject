using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSlide : MonoBehaviour
{
    public Animator A2;
    private int animState = 0;
    private int maxState = 1;
    private int minState = 0;
    private int slideRight = 1;
    private int slideLeft = 0;
    public float timer;


    void Start()
    {
        

    }
    void Update()
    {
        if (animState == 1)
        {
            A2.SetInteger("menuButtonsClicked", slideRight);


        }
        else
        {
            A2.SetInteger("menuButtonsClicked", slideLeft);

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

        



    }

    public void Timer()
    {
        timer += 1 * Time.deltaTime;
    }

}
