using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvNPC : MonoBehaviour
{
    [SerializeField] private string _NPCName;
    [SerializeField] private string[] _chatDialogue;
    [SerializeField] private GameObject _UIDiplay;

    private void Awake()
    {
        this.gameObject.name = _NPCName;
        this.gameObject.GetComponentInChildren<TextMeshPro>().text = _NPCName;
    }

    void OnMouseDown()
    {
        Debug.Log("Hit the object " + this.gameObject.name);
        StartCoroutine(ChatDialogue());
    }

    private IEnumerator ChatDialogue()
    {
        Debug.Log("Starting Chat");
        // Loop through dialogue array diaplying it on UI
        foreach (string _sScentence in _chatDialogue)
        {
            _sScentence.PadRight(_sScentence.Length + 1, ' '); // add a space to each word
            foreach (char _letters in _sScentence.ToCharArray())
            {
                //apply letters to dialogue text Game Object
                _UIDiplay.GetComponent<Text>().text += _letters;
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield break;

    }
}

