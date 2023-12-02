using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;

    public TMP_Text Question_Header;
    public TMP_Text Answer_A;
    public TMP_Text Answer_B;
    public TMP_Text Answer_C;

    public TMP_Text Timer_Text;
    public TMP_Text QuestionsAmount_Text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else Destroy(this.gameObject);

        Answer_A.transform.parent.GetComponent<Button>().onClick.AddListener(() => QuizManager.Instance.AnswerQuestion(CorrectAnswer.A));
        Answer_B.transform.parent.GetComponent<Button>().onClick.AddListener(() => QuizManager.Instance.AnswerQuestion(CorrectAnswer.B));
        Answer_C.transform.parent.GetComponent<Button>().onClick.AddListener(() => QuizManager.Instance.AnswerQuestion(CorrectAnswer.C));
    }

    public void SetQuestion(QuizQuestion question)
    {
        Question_Header.text = question.Question;
        Answer_A.text = question.Answer.AnswerA;
        Answer_B.text = question.Answer.AnswerB;
        Answer_C.text = question.Answer.AnswerC;
    }

    public void SetTime(int time)
    {
        Timer_Text.text = time.ToString();
    }
}
