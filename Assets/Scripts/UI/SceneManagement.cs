using UnityEngine;
using UnityEngine.SceneManagement;
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

    private Scene _currentScene;

    private void Awake()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    public void Restart()
    {
        switch (onRestartAction)
        {
            case OnRestartAction.LoadThisScene:
                SceneManager.LoadScene(_currentScene.buildIndex);
                break;
            case OnRestartAction.LoadNextScene:
                if (_currentScene.buildIndex < SceneManager.sceneCountInBuildSettings-1)
                {
                    SceneManager.LoadScene(_currentScene.buildIndex + 1);
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
                SceneManager.LoadScene(_currentScene.buildIndex);
                break;
            case OnWinAction.LoadNextScene:
                if (_currentScene.buildIndex < SceneManager.sceneCountInBuildSettings-1)
                {
                    SceneManager.LoadScene(_currentScene.buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }
}