using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Questions
{
    // Question
    public string question;
    // False answer
    public string wrongAnswerOne;
    public string wrongAnswerTwo;
    public string wrongAnswerThree;
    // Correct answer
    public string answer;
}