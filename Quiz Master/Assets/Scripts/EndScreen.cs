using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI finalScoreText;

    [SerializeField]
    ScoreKeeper scoreKeeper;

    public void ShowFinalScore()
    {
        float finalScore = scoreKeeper.GetFinalScore();

        if (finalScore > 70)
        {
            finalScoreText.text = $"Congratulations!\nYou got a score of {scoreKeeper.GetFinalScore():F2}%";
        }
        else
        {
            finalScoreText.text = $"You failed the quiz.\nYour final score was {scoreKeeper.GetFinalScore():F2}%";
        }
    }
}