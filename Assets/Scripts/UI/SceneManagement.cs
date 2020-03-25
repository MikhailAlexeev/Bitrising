﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public enum OnRestartAction
    {
        LoadThisScene,
        LoadNextScene
    }
    
    public enum OnWinAction
    {
        LoadThisScene,
        LoadNextScene
    }

    public OnRestartAction onRestartAction;
    public OnWinAction onWinAction;

    private Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void Restart()
    {
        switch (onRestartAction)
        {
            case OnRestartAction.LoadThisScene:
                SceneManager.LoadScene(currentScene.buildIndex);
                break;
            case OnRestartAction.LoadNextScene:
                if (currentScene.buildIndex < SceneManager.sceneCountInBuildSettings-1)
                {
                    SceneManager.LoadScene(currentScene.buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }

    public void Win()
    {
        switch (onWinAction)
        {
            case OnWinAction.LoadThisScene:
                SceneManager.LoadScene(currentScene.buildIndex);
                break;
            case OnWinAction.LoadNextScene:
                if (currentScene.buildIndex < SceneManager.sceneCountInBuildSettings-1)
                {
                    SceneManager.LoadScene(currentScene.buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }
}