using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenuAttribute(fileName = "LevelInformation", menuName = "ScriptableObjects/LevelInfo", order = 1)]
public class LevelInfo : ScriptableObject
{
    public int levelNumber;
}
