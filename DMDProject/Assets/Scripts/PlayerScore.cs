using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int _score;
    private static int _highScore;
    private AudioSource _audioSource;
    private LaunchingCamera _launchingCamera;
    public int Score => _score;
    public int HighScore => _highScore;

    private void Start()
    {
        _launchingCamera = FindObjectOfType<LaunchingCamera>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<CollectablePoints>()) return;
        _audioSource.Play();
        _score += other.GetComponent<CollectablePoints>().scoreAmount;
        scoreText.text = _score.ToString();
        other.gameObject.SetActive(false);
        var vel = _launchingCamera.rb.velocity;
        if(vel.y < 0) vel.y = -vel.y * 4;
        _launchingCamera.rb.AddForce(0,vel.y,0);
        if (_score > _highScore) _highScore = _score;
    }
}
