using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50))
            {
                if (hit.transform.CompareTag("Node"))
                {
                    agent.destination = hit.transform.position;
                }
            }
        }
    }
}
