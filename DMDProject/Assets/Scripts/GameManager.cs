using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private RaycastHit _hit;
    private GameObject _chosenNode;
    [SerializeField] private GameObject agent;
    [SerializeField] private List<GameObject> nodes;
    [SerializeField] private new Camera camera;
    private NavMeshAgent Agent => agent.GetComponent<NavMeshAgent>(); 
    private LoadLevelInfo LevelInfo => _chosenNode.GetComponent<LoadLevelInfo>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNodes();
        CheckDistance();
    }

    private void CheckForNodes()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out _hit, 50))
            {
                foreach (var node in nodes)
                {
                    if (_hit.transform != node.transform) continue;
                    Agent.destination = _hit.transform.position;
                    _chosenNode = node;
                    break;
                }
            }
        }
    }
    
    private void CheckDistance()
    {
        if (!_chosenNode) return;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        if (Agent.hasPath) yield break;
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(LevelInfo.levelNumb);
    }
}
