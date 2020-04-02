using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killer : MonoBehaviour
{
    [Header("UI")] 
    public Button restartButton;

    public VfxSpawner vfxSpawner;
    // Start is called before the first frame update
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            if (vfxSpawner != null)
            {
                vfxSpawner.PlayKilledVFX();
            }
            restartButton.gameObject.SetActive(true);
        }
    }
}
