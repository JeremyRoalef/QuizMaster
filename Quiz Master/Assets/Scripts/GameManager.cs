using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Quiz quiz;

    [SerializeField]
    EndScreen endScreen;

    const string MAIN_MENU_SCENE = "MainMenuScene";

    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }


    void Update()
    {
        if (!quiz.IsComplete) return;

        quiz.HideGame();
        endScreen.gameObject.SetActive(true);
        endScreen.ShowFinalScore();
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnButtonReturnToMainMenuClick()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}
