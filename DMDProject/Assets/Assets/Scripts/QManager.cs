using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QManager : MonoBehaviour
{
    [SerializeField] GameObject bossHealthBar;
    [SerializeField] GameObject answerPopUp;

    [SerializeField] QScriptable questionnaire;
    [SerializeField] TextMeshProUGUI questionUI;
    [SerializeField] Text q1, q2, q3, q4;
    private List<string> randomAssignQuestions = new List<string>(4);
    private int questionNum = 1;



    void Start()
    {
        //add answer UI elements to a list
        AssignArray();

        //display first question
        DisplayQuestion();
    }

    public void CheckAnswerButtonOne()
    {
        if (q1.text == questionnaire.questions[questionNum - 1].answer)
        {
            DamageBoss();
        }
        else
        {
            DisplayFail();
        }
    }
    public void CheckAnswerButtonTwo()
    {
        if (q2.text == questionnaire.questions[questionNum - 1].answer)
        {
            DamageBoss();
        }
        else
        {
            DisplayFail();
        }
    }
    public void CheckAnswerButtonThree()
    {
        if (q3.text == questionnaire.questions[questionNum - 1].answer)
        {
            DamageBoss();
        }
        else
        {
            DisplayFail();
        }
    }
    public void CheckAnswerButtonFour()
    {
        if (q4.text == questionnaire.questions[questionNum - 1].answer)
        {
            DamageBoss();
        }
        else
        {
            DisplayFail();
        }
    }

    void DamageBoss()
    {
        // call damage boss function on healthbar
        Debug.Log("Boss Damaged!");
        bossHealthBar.GetComponent<QHealthBar>().QuestionnaireBossTakeDamage();
        answerPopUp.GetComponent<QAnswerPopUp>().StartCorrect();

        //move onto next question
        questionNum++;
        DisplayQuestion();
    }

    void DisplayFail()
    {
        // display failed message
        Debug.Log("Wrong Answer!");
        answerPopUp.GetComponent<QAnswerPopUp>().StartWrong();

        //move onto next question
        questionNum++;
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        //apply questions to UI
        for (int i = 0; i < questionNum; i++)
        {
            Debug.Log("Questions Applied");
            //apply current question to UI
            questionUI.text = questionnaire.questions[i].question;
            // randomly assign the answers to the buttons
            AssignQuestions();

        }
    }

    void AssignQuestions()
    {
        AssignArray();
        RandomizeArray();
        for (int i = 0; i < questionNum; i++)
        {
            q1.text = randomAssignQuestions[i];
            i++;
            q2.text = randomAssignQuestions[i];
            i++;
            q3.text = randomAssignQuestions[i];
            i++;
            q4.text = randomAssignQuestions[i];
        }
    }

    void RandomizeArray()
    {
        // itterate through list and randomize it
        for (int posOfList = 0; posOfList < randomAssignQuestions.Count; posOfList++)
        {
            //store current list index in txt
            string txt = randomAssignQuestions[posOfList];
            //get number based on the length of list
            int randomizeList = Random.Range(0, randomAssignQuestions.Count);
            //take object in position and put it in the random position
            randomAssignQuestions[posOfList] = randomAssignQuestions[randomizeList];
            //assign object that is randomized
            randomAssignQuestions[randomizeList] = txt;
        }
    }

    void AssignArray()
    {
        //if array is full clear and try again
        if (randomAssignQuestions.Count > 0)
        {
            randomAssignQuestions.Clear();
            AssignArray();
        }
        // assign elements to array
        else
        {
            randomAssignQuestions.Add(questionnaire.questions[questionNum - 1].wrongAnswerOne);
            randomAssignQuestions.Add(questionnaire.questions[questionNum - 1].wrongAnswerTwo);
            randomAssignQuestions.Add(questionnaire.questions[questionNum - 1].wrongAnswerThree);
            randomAssignQuestions.Add(questionnaire.questions[questionNum - 1].answer);
        }
    }
}
