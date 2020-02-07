using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade : MonoBehaviour
    
{
    private float fadeDuration = 2f;
    private CanvasGroup cg1;

    void Start()
    {
        cg1 = GetComponent<CanvasGroup>();
        
        
    }

   
    public void fadeOut()
    {
        cg1.alpha = 0;
    }

    public void fadeIn()
    {
        cg1.alpha = 1;
    }

}
