﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
        GetComponent<UIStatus>().IsScenePaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<UIStatus>().IsScenePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        GetComponent<UIMenu>().EnableTutorial();
    }

    public void ShowCredits()
    {
        GetComponent<UIMenu>().EnableCredits();
    }

    public void ShowMenu()
    {
        GetComponent<UIMenu>().EnableMenu();
    }

    public void Exit()
    {
        Application.Quit();
    }
}