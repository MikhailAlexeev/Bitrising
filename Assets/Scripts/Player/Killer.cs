using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killer : MonoBehaviour
{
    [Header("UI")] 
    public Button restartButton;
    // Start is called before the first frame update
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            restartButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
