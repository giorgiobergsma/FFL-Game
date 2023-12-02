using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    public List<Transform> Spawnpoints = new List<Transform>();
    public PlayerObject PlayerPrefab;

    public List<QuizQuestion> Questions = new List<QuizQuestion>();
    private List<QuizQuestion> QuestionsList;
    private QuizQuestion CurrentQuestion;
    private int CorrectAnswers = 0;
    private int WrongAnswers = 0;
    private int QuestionsAnswered = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else Destroy(this.gameObject);
    }

    private void Start()
    {
        // Start game loop
        for (int i = 0; i < Spawnpoints.Count; i++)
        {
            PlayerObject playerObject = Instantiate(PlayerPrefab, Spawnpoints[0].position, Quaternion.identity);
            if (i == 0) // setup player
            {
                
            }

            else // setup opponent
            {

            }
        }


            // Set questions list and shuffle
            QuestionsList = Questions;
        QuestionsList.Shuffle();

        CurrentQuestion = QuestionsList[0];
        HudManager.Instance.SetQuestion(QuestionsList[0]);
        StartCoroutine(Timer());
    }

    public void AnswerQuestion(CorrectAnswer answer)
    {
        StopCoroutine(Timer());

        // Answer is correct
        if (CurrentQuestion.AnswerQuestion(answer))
        {
            CorrectAnswers++;

            // Correct jump animation
            
        }

        else // Answer is wrong
        {
            WrongAnswers++;

            // Fail jump animation
        }

        QuestionsAnswered++;

        // check if we reached the end of the map

        // if we did not reach the end start the next question
        NextQuestion();
    }

    public void NextQuestion()
    {
        if (QuestionsList.Count > QuestionsAnswered)
        {
            CurrentQuestion = QuestionsList[QuestionsAnswered];
            HudManager.Instance.SetQuestion(QuestionsList[QuestionsAnswered]);
            StartCoroutine(Timer());

            HudManager.Instance.QuestionsAmount_Text.text = QuestionsAnswered.ToString() + "/" + QuestionsList.Count.ToString();
        }

        else
        {
            // End game
        }
    }

    private IEnumerator Timer()
    {
        int time = 20;
        HudManager.Instance.SetTime(time);
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            HudManager.Instance.SetTime(time);
        }

        AnswerQuestion(CorrectAnswer.Wrong);
    }
}
