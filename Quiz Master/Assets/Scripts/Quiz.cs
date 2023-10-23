using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();

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

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;


    public bool boolIsComplete;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
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

        if (intIndex == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButton[intIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            intCorrectAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string strCorrectAnswer = currentQuestion.GetAnswer(intCorrectAnswerIndex);
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
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";

        if (progressBar.value == progressBar.maxValue)
        {
            boolIsComplete = true;
        }
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            scoreKeeper.IncrementQuestionsSeen();
        }


    }

    void GetRandomQuestion()
    {
        int intIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[intIndex];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }

    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();



        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
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
