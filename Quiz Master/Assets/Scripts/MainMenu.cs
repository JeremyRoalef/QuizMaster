using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const string CITA_212_QUESTIONS_SCENE = "CITA212QuestionsScene";
    const string GITHUB_QUESTIONS_SCENE = "GitHubQuestionsScene";
    const string MATH_QUESTIONS_SCENE = "MathQuestionsScene";
    const string PROGRAMMING_QUESTIONS_SCENE = "ProgrammingQuestionsScene";

    public void OnPlayCITA212QuestionsQuizSelected()
    {
        SceneManager.LoadScene(CITA_212_QUESTIONS_SCENE);
    }
    public void OnPlayGitHubQuestionsQuizSelected()
    {
        SceneManager.LoadScene(GITHUB_QUESTIONS_SCENE);
    }
    public void OnPlayMathQuestionsQuizSelected()
    {
        SceneManager.LoadScene(MATH_QUESTIONS_SCENE);
    }
    public void OnPlayProgrammingQuestionsQuizSelected()
    {
        SceneManager.LoadScene(PROGRAMMING_QUESTIONS_SCENE);
    }
}
