using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TGameManager : MonoBehaviour
{
    [SerializeField] float missedShots;
    [SerializeField] float hitShots;
    [SerializeField] GameObject endGameGUI;
    [SerializeField] TextMeshProUGUI winLossText, hitScore, missScore;
    [SerializeField] GameObject missedScript;



    private void Update()
    {
        missedShots = float.Parse(missScore.text);
        hitShots = float.Parse(hitScore.text);
        //store the hit and missed shots

        //if missed 5 then lose game
        if (missedShots > 5)
        {
            endGameGUI.SetActive(true);
            winLossText.text = "You Lose!";
        }
        else if (hitShots >= 50) //if hit 50 win game
        {
            endGameGUI.SetActive(true);
            winLossText.text = "You Win!";
        }
    }

    public void RestartGame()
    {
        missedShots = 0f;
        hitShots = 0f;
        hitScore.text = "0";
        missScore.text = "0";
        endGameGUI.SetActive(false);
        missedScript.GetComponent<TMissed>().numOfMisses = 0f;
    }
}
