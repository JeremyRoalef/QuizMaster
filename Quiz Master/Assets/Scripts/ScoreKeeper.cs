using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;

    int questionsAnsweredCorrectly = 0;
    int totalQuestionsAnswered = 0;

    public int GetCorrectAnswers()
    {
        return questionsAnsweredCorrectly;
    }

    public void IncrementCorrectAnswers()
    {
        questionsAnsweredCorrectly++;
    }

    public void IncrementQuestionsSeen()
    {
        totalQuestionsAnswered++;
    }

    public void UpdateScore()
    {
        float score = totalQuestionsAnswered == 0? 0 : questionsAnsweredCorrectly / (float)totalQuestionsAnswered * 100;
        scoreText.text = $"Score: {score:F2}%";
    }

    public float GetFinalScore()
    {
        return questionsAnsweredCorrectly / (float)totalQuestionsAnswered * 100;
    }
}
