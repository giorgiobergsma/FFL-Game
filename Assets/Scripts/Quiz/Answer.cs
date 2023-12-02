using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer
{
    [TextArea]
    public string AnswerA;
    [TextArea]
    public string AnswerB;
    [TextArea]
    public string AnswerC;

    public CorrectAnswer CorrectAnswer;
}

public enum CorrectAnswer
{
    A,
    B,
    C,
    Wrong,
}