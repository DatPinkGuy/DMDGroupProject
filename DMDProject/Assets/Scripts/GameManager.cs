using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GameManager : MonoBehaviour
{
    private RaycastHit _hit;
    [SerializeField] private GameObject agent;
    [SerializeField] private List<GameObject> nodes;
    [SerializeField] private new Camera camera;
    private NavMeshAgent Agent => agent.GetComponent<NavMeshAgent>(); 
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
                        Agent.destination = _hit.transform.position;
                        break;
                    }
                }
            }
        }
    }
}
