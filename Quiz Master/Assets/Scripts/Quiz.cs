using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Canvas References")]
    [SerializeField]
    TextMeshProUGUI questionText;

    [SerializeField] 
    Slider progressBar;

    [SerializeField]
    AnswerButton[] answerButtons;

    [SerializeField]
    GameObject gamePanel;

    [Header("Sprites")]
    [SerializeField]
    Sprite defaultAnswerSprite;

    [SerializeField] 
    Sprite correctAnswerSprite;



    [Header("Other References")]
    [SerializeField]
    List<QuestionSO> questions = new List<QuestionSO>();

    [SerializeField]
    Timer timer;

    [SerializeField]
    ScoreKeeper scoreKeeper;



    QuestionSO currentQuestion;

    int selectedButtonIndex = -1;

    public bool IsComplete { get; private set; }
    bool isAnsweringQuestion;
    bool hasAnsweredEarly;

    static int NO_BUTTON_SELECTED_INDEX = -1;

    void Awake()
    {
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;

        //Start quiz by answering the question
        isAnsweringQuestion = true;
        GetRandomCurrentQuestion();
        DisplayQuestion();
        timer.SetTimer(isAnsweringQuestion);
        scoreKeeper.UpdateScore();
    }

    void Update()
    {
        if (timer.isOutOfTime)
        {
            //Swap state of answering question
            isAnsweringQuestion = !isAnsweringQuestion;

            //Reset the timer
            timer.SetTimer(isAnsweringQuestion);
            
            //If the time to answer question has run out, then show the answer. Otherwise, start next question
            if (!isAnsweringQuestion)
            {
                //Check if the player answered early
                if (!hasAnsweredEarly)
                {
                    selectedButtonIndex = NO_BUTTON_SELECTED_INDEX;
                }

                DisplayAnswer(selectedButtonIndex);
                SetButtonState(false);
                return;
            }

            //Check if there are no more quesitons to answer
            if (answerButtons.Length == 0)
            {
                IsComplete = true;
                return;
            }

            //Load the next question
            GetNextQuestion();
        }
    }

    void DisplayAnswer(int selectedButtonIndex)
    {
        Image buttonImage;

        Debug.Log("Selected button index: "+ selectedButtonIndex);
        Debug.Log("correct answer index: " + currentQuestion.GetCorrectAnswerIndex());

        if (selectedButtonIndex == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[selectedButtonIndex].GetImage();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            int correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string strCorrectAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "The correct answer was;\n" + strCorrectAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetImage();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
    public void OnAnswerSelected(int selectedButtonIndex)
    {
        //Set the selected index
        this.selectedButtonIndex = selectedButtonIndex;
        hasAnsweredEarly = true;

        timer.EndTimer();
    }
    void GetNextQuestion()
    {
        if (questions.Count <= 0)
        {
            //quiz is complete
            IsComplete = true;
            scoreKeeper.IncrementQuestionsSeen();
            return;
        }

        hasAnsweredEarly = false;
        SetButtonState(true);
        SetDefaultButtonSprite();
        GetRandomCurrentQuestion();
        DisplayQuestion();
        progressBar.value++;
        scoreKeeper.IncrementQuestionsSeen();
        scoreKeeper.UpdateScore();
    }
    void GetRandomCurrentQuestion()
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
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetTextMeshProUGUI();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
    void SetButtonState(bool boolState)
    {
        for(int i = 0; i< answerButtons.Length;i++)
        {
            Button button = answerButtons[i].GetButton();
            button.interactable = boolState;
        }
    }
    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage;
            buttonImage = answerButtons[i].GetImage();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    public void HideGame()
    {
        gamePanel.SetActive(false);
    }
}
