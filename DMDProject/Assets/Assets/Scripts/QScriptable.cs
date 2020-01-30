using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Questions", menuName = "ScriptableObjects/Questionnaire", order = 1)]
public class QScriptable :  ScriptableObject
{
    public List<Questions> questions = new List<Questions>();
}
