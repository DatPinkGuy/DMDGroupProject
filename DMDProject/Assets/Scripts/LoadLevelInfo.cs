using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelInfo : MonoBehaviour
{
    public LevelInfo levelInfo;
    public int levelNumb;
    // Start is called before the first frame update
    void Start()
    {
        levelNumb = levelInfo.levelNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
