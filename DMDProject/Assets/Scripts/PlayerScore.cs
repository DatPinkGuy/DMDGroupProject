using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int _score;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<CollectablePoints>()) return;
        _score += other.GetComponent<CollectablePoints>().scoreAmount;
        scoreText.text = _score.ToString();
    }
}
