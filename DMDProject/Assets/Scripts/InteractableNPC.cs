using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] GameObject dialogueUI;

    private void OnMouseDown()
    {
        dialogueUI.SetActive(true);
    }
}
