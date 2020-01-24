using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCSpawner : MonoBehaviour
{
    //prefab of npc to spawn
    [SerializeField] GameObject npcPrefab;
    //amount to spawn
    [SerializeField] int npcAmount;
    //varaible of biome manager to get the list attached to it
    BiomeManager biome;


    void Start()
    {
        SpawnNPCS();
    }

    void SpawnNPCS()
    {
        //spawn amount of npcs
        for (int i = 0; i < npcAmount; i++)
        {
            //hardcode vector3 to lock the spawn coords
            Instantiate(npcPrefab, new Vector3(i * 0.2f, 0.0f, 0.0f), Quaternion.identity);
            //get sprite from biome manager and apply to npc
            npcPrefab.GetComponent<Image>().sprite = biome.spawnableScript[biome.bioEnementNum].nonPlayerSprite;
        }
    }
}
