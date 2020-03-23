using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    public Player player;
    public Button restartButton;
    
    void Update()
    {
        PlayerOffScreen();
    }

    public void PlayerOffScreen()
    {
        if (player.transform.position.x < -10.3f || 10.3f < player.transform.position.x)
        {
            player.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
     
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
