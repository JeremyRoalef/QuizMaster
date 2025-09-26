using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timeToAnswerQuestion = 30f;
    
    [SerializeField]
    float timeToShowCorrectAnswer = 10f;

    [SerializeField]
    Image timerImage;

    float remainingTime;
    float maxTime;

    public bool isOutOfTime { get; private set; }

    void Update()
    {
        UpdateTimer();
        SetTimerImage();
    }

    private void SetTimerImage()
    {
        //time image fill amount is equal to the proportion of remaining time to the max time
        timerImage.fillAmount = remainingTime < 0? 0 : remainingTime / maxTime;
    }

    void UpdateTimer()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            isOutOfTime = true;
        }
    }

    public void SetTimer(bool isAnsweringQuestion)
    {
        if (isAnsweringQuestion)
        {
            //Set time for answering question
            remainingTime = timeToAnswerQuestion;
        }
        else
        {
            //Set time to show correct answer
            remainingTime = timeToShowCorrectAnswer;
        }

        maxTime = remainingTime;
        isOutOfTime = false;
    }
    public void EndTimer()
    {
        remainingTime = 0;
    }
}
