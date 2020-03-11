using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{

    public RectTransform panel1;
    private CanvasGroup cg1;

    void Start()
    {
        panel1.transform.position = new Vector2(- 251.6f, 0f); 
       
    }
    void Update()
    {
        ;
    }

    public void MenuOpening()
    {
        if (Input.GetMouseButtonDown(0)) ///// need to change to touch input 
        {
           panel1.transform.position = new Vector2(-339.7f, 0f);
        }
    }
    public void MenuClosing()
    {
        if (Input.GetMouseButtonDown(0)) ///// need to change to touch input 
        {
            panel1.transform.position = new Vector2(-251.6f, 0f);
        }
    }


}