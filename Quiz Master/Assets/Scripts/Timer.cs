using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float fltTimeToCompleteQuestion = 30f;
    [SerializeField] float fltTimeToShowCOrrectAnswer = 10f;

    public bool boolIsAnsweringQuestion = false;

    float fltTimerValue;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        fltTimerValue -=Time.deltaTime;

        if (boolIsAnsweringQuestion) {
            if (fltTimerValue <=0)
            {
                boolIsAnsweringQuestion=false;
                fltTimerValue = fltTimeToShowCOrrectAnswer;
            }
        }
        else
        {
            if (fltTimerValue <=0)
            {
                boolIsAnsweringQuestion = true;
                fltTimerValue = fltTimeToCompleteQuestion;
            }
        }

        if (fltTimerValue <= 0)
        {
            fltTimerValue = fltTimeToCompleteQuestion;

        }

        Debug.Log(fltTimerValue);
    }

}
