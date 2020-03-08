using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMissed : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI missedText;
    public float numOfMisses = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        numOfMisses++;
        missedText.text = numOfMisses.ToString(); 

        Destroy(collision.gameObject);
    }
}
