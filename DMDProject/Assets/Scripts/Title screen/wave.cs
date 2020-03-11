using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{

    Animator button;

    void Start()
    {
        button = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) ///// need to change to touch input 
        {
            button.SetTrigger("Active");
        }
    }
}


