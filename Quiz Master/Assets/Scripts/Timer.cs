using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float fltTimeToCompleteQuestion = 30f;
    [SerializeField] float fltTimeToShowCOrrectAnswer = 10f;

    public bool boolIsAnsweringQuestion = false;

    float fltTimerValue;
    public float fltFillFraction;
    public bool boolLoadNextQuestion = true;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        fltTimerValue = 0;
    }

    void UpdateTimer()
    {
        fltTimerValue -=Time.deltaTime;

        if (boolIsAnsweringQuestion) {
            if (fltTimerValue >0)
            {
                fltFillFraction = fltTimerValue / fltTimeToCompleteQuestion;
            }
            else
            {
                boolIsAnsweringQuestion = false;
                fltTimerValue = fltTimeToShowCOrrectAnswer;
            }
        }
        else
        {
            if (fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToShowCOrrectAnswer;
            }
            else
            {
                boolIsAnsweringQuestion = true;
                fltTimerValue = fltTimeToCompleteQuestion;
                boolLoadNextQuestion = true;
            }
        }

        if (fltTimerValue <= 0)
        {
            fltTimerValue = fltTimeToCompleteQuestion;

        }

        Debug.Log(boolIsAnsweringQuestion + ": " + fltTimerValue + " = " + fltFillFraction);
    }

}
