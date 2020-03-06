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
    [SerializeField] private Animator animator;
    private LoadLevelInfo LevelInfo => _chosenNode.GetComponent<LoadLevelInfo>();
    private NavMeshHit _navMeshHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animating();
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

    private void Animating()
    {
        if (!Agent.hasPath)
        {
            animator.Play("idle", 0);
            return;
        }
        if ((Agent.velocity.x > 0) && Agent.velocity.z > Agent.velocity.x)
        {
            animator.Play("walk away", 0);
        }
        else if ((Agent.velocity.x < 0 || Agent.velocity.x > 0) && Agent.velocity.z < 0 &&  Agent.velocity.z < Agent.velocity.x)
        {
            animator.Play("walkforawrd", 0);
        }
        else if (Agent.velocity.x > 0 && Agent.velocity.z < Agent.velocity.x)
        {
            animator.Play("walk right", 0);
        }
        else
        {
            animator.Play("walklleft", 0);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        if (Agent.hasPath) yield break;
        yield return new WaitForSecondsRealtime(2);
        if(!Agent.hasPath) SceneManager.LoadScene(LevelInfo.levelNumb);
    }
}
