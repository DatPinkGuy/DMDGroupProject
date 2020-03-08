using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishGameManager : MonoBehaviour
{
    [SerializeField] GameObject catchButton, startButton, caughtText, winLossPanel;
    [SerializeField] TextMeshProUGUI caughtNum, winPanelText;
    [SerializeField] float fishingTimer = 0f;
    [SerializeField] float catchTimer = 0f;
    float caughtAmount;
    bool canbeCaught = false;
    bool startFish = false;
    float CatchstopTime;
    bool timerCanStart = false;

    private void Update()
    {
        if (startFish)
        {
            caughtText.SetActive(false);
            fishingTimer += Time.deltaTime;
            float stopTime = Random.Range(2f, 10f);
            if (fishingTimer >= stopTime)
            {
                // fish is on the reel
                startFish = false;
                catchButton.SetActive(true);
                timerCanStart = true;
                fishingTimer = 0f;
            }
        }

        if (timerCanStart)
        {
            catchTimer += Time.deltaTime;
            CatchstopTime = Random.Range(2f, 4f);
        }
        if (canbeCaught)
        {
            startButton.SetActive(true);
            catchButton.SetActive(false);
            caughtText.SetActive(true);
            caughtText.GetComponent<TextMeshProUGUI>().text = "Caught some Junk!";
            caughtAmount++;
            caughtNum.text = caughtAmount.ToString();
            canbeCaught = false;
            timerCanStart = false;
            catchTimer = 0f;
        }

        if (catchTimer >= CatchstopTime)
        {
            startButton.SetActive(true);
            catchButton.SetActive(false);
            caughtText.GetComponent<TextMeshProUGUI>().text = "Debris Got Away!";
            catchTimer = 0f;
            timerCanStart = false;
        }


        if (caughtAmount > 5)
        {
            winLossPanel.SetActive(true);
            winPanelText.text = "You Win!";
        }
    }

    public void StartFishing()
    {
        startButton.SetActive(false);
        startFish = true;
    }

    public void CatchFish()
    {
        canbeCaught = true;
    }

    public void RestartFishGame()
    {
        caughtAmount = 0f;
        catchButton.SetActive(false);
        startButton.SetActive(true);
        winLossPanel.SetActive(false);
    }
}
