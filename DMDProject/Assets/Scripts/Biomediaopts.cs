using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Biomediaopts : MonoBehaviour
{
    [SerializeField] GameObject npcDialogueBox;
    [SerializeField] GameObject biomeInformationBox;
    [SerializeField] GameObject dialogueOptionsBox;
    [SerializeField] string optionOneText;
    [SerializeField] string optionTwoText;
    [SerializeField] string optionThreeText;
    [SerializeField] string optionFourText;
    [SerializeField] float messageTimer = 3f;

    public void BiomeOptionOne()
    {
        //Display Biome Information
        biomeInformationBox.SetActive(true);
        dialogueOptionsBox.SetActive(false);
        //NPC dialogue box appears
        npcDialogueBox.SetActive(true);
        npcDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = optionOneText;
        StartCoroutine(BiomeMessageDisplayTimer());
    }

    public void BiomeOptionTwo()
    {
        // reply with own name
        npcDialogueBox.SetActive(true);
        npcDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = optionTwoText;
        StartCoroutine(BiomeMessageDisplayTimer());
    }
    public void BiomeOptionThree()
    {
        npcDialogueBox.SetActive(true);
        npcDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = optionThreeText;
        StartCoroutine(BiomeMessageDisplayTimer());
    }

    public void BiomeOptionFour()
    {
        npcDialogueBox.SetActive(true);
        npcDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = optionFourText;
        StartCoroutine(BiomeMessageDisplayTimer());
    }

    public void CloseBiomeBox()
    {
        biomeInformationBox.SetActive(false);
        dialogueOptionsBox.SetActive(true);
    }

    IEnumerator BiomeMessageDisplayTimer()
    {

        yield return new WaitForSeconds(messageTimer);
        npcDialogueBox.SetActive(false);
        StopCoroutine(BiomeMessageDisplayTimer());
    }
}
