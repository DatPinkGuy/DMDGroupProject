using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiomeManager : MonoBehaviour
{
    //UI varaibles
    [SerializeField] GameObject uiBG, playerSprite; 
    //Scriptable object
    [SerializeField] public List<ScriptableBiome> spawnableScript;
    //Its public for a reason... I think
    public int bioEnementNum;

    private void Start()
    {
        //test
        ApplyBiome(bioEnementNum);

    }



    private void ApplyBiome(int BiomeNum)
    {
        //apply sprites from the scriptable object
        uiBG.GetComponent<Image>().sprite = spawnableScript[BiomeNum].backGroundSprite;
        playerSprite.GetComponent<Image>().sprite = spawnableScript[BiomeNum].playerSprite;
    }
}
