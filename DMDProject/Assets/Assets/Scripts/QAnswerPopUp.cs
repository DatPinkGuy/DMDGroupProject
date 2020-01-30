using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QAnswerPopUp : MonoBehaviour
{
    [SerializeField] GameObject popUpText;
    [SerializeField] float timer = 1f;

    public void StartCorrect()
    {
        StartCoroutine(Correct());
    }
    public void StartWrong()
    {
        StartCoroutine(Wrong());
    }

    IEnumerator Correct()
    {
        popUpText.SetActive(true);
        popUpText.GetComponentInChildren<TextMeshProUGUI>().text = "Correct!";
        yield return new WaitForSeconds(timer);
        popUpText.SetActive(false);
    }

    IEnumerator Wrong()
    {
        popUpText.SetActive(true);
        popUpText.GetComponentInChildren<TextMeshProUGUI>().text = "Wrong!";
        yield return new WaitForSeconds(timer);
        popUpText.SetActive(false);
    }
}
