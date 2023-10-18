using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButton;
    int intCorrectAnswerIndex;
    bool boolHasAnsweredEarly;


    [Header("Buttons")]
    [SerializeField]  Sprite defaultAnswerSprite;
    [SerializeField]  Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
        //DisplayQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fltFillFraction;
        if (timer.boolLoadNextQuestion)
        {
            boolHasAnsweredEarly = false;
            GetNextQuestion();
            timer.boolLoadNextQuestion = false;
        }
        else if (!boolHasAnsweredEarly && !timer.boolIsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void DisplayAnswer(int intIndex)
    {
        Image buttonImage;

        if (intIndex == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButton[intIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            intCorrectAnswerIndex = question.GetCorrectAnswerIndex();
            string strCorrectAnswer = question.GetAnswer(intCorrectAnswerIndex);
            questionText.text = "The correct answer was;\n" + strCorrectAnswer;
            buttonImage = answerButton[intCorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    public void OnAnswerSelected(int intIndex)
    {
        boolHasAnsweredEarly = true;
        DisplayAnswer(intIndex);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();



        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
    void SetButtonState(bool boolState)
    {
        for(int i = 0; i< answerButton.Length;i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.interactable = boolState;
        }
    }

    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image buttonImage;
            buttonImage = answerButton[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
