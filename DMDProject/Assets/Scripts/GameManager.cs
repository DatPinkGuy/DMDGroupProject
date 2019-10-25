using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private RaycastHit _hit;
    private LoadLevelInfo _levelInformation;
    public Sprite outfit;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (!outfit) return;
        player.GetComponent<SpriteRenderer>().sprite = outfit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 50))
            {
                if (_hit.transform.GetComponent(typeof(LoadLevelInfo)))
                {
                    _levelInformation = _hit.transform.GetComponent<LoadLevelInfo>();
                    SceneManager.LoadScene(_levelInformation.levelNumb);
                }
            }
        }

    }
}
