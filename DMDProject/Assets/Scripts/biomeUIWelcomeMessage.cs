using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class biomeUIWelcomeMessage : MonoBehaviour
{
    [SerializeField] GameObject introUI;
    [SerializeField] string messageToSay;
    [SerializeField] float messageTimer = 5f;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = messageToSay;
        StartCoroutine(WelcomeMessage());
    }
    IEnumerator WelcomeMessage()
    {
        
        yield return new WaitForSeconds(messageTimer);
        introUI.SetActive(false);
        //yield break;
        StopCoroutine(WelcomeMessage());
    }
}
