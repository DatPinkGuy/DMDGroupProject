using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] GameObject dialogueUI;
    private void OnTrigger2D(Collider2D collision)
    {
            dialogueUI.SetActive(true);
    }
}
