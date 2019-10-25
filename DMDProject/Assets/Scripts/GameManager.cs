using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private RaycastHit _hit;
    [SerializeField] private List<GameObject> nodes;
    [SerializeField] private new Camera camera;
    private GameObject _chosenNode;
    private LoadLevelInfo LevelInfo => _chosenNode.GetComponent<LoadLevelInfo>();
    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out _hit, 50))
            {
                foreach (var node in nodes)
                {
                    if (_hit.transform == node.transform)
                    {
                        _chosenNode = node;
                        SceneManager.LoadScene(LevelInfo.levelNumb);
                    }
                }
            }
        }
    }
}
