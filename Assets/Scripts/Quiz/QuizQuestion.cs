using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question", order = 111)]
public class QuizQuestion : ScriptableObject
{
    [TextArea]
    public string Question;
    public Answer Answer;

    public bool AnswerQuestion(CorrectAnswer answer)
    {
        if (answer == Answer.CorrectAnswer) return true;
        else return false;
    }
}
