using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSound : MonoBehaviour
{
    public AudioClip coin;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "coin")
        {
            audio.clip = coin;
            audio.Play();
        }
    }
}
