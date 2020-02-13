using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] float npcMoveSpeed;

    private void Start()
    {
      
    }
    private void Update()
    {
        NPCMovement();
    }

    void NPCMovement()
    {
        //TODO: squash and stretch the npc
        GetComponent<Rigidbody2D>().velocity = new Vector2(npcMoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(CollosionDelay());
    }

    IEnumerator CollosionDelay()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        npcMoveSpeed *= -1;
        StopCoroutine(CollosionDelay());
    }
}
