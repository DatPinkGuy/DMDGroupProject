using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TEnemy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float pointsToGive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float tempScore = float.Parse(scoreText.text);
        tempScore += pointsToGive;
        scoreText.text = tempScore.ToString();

        Destroy(collision.gameObject);
    }
}
