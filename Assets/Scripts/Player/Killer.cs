using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killer : MonoBehaviour
{
    [Header("UI")] 
    public Button restartButton;
    
    private VfxSpawner _vfxSpawner;

    private void Start()
    {
        _vfxSpawner = GetComponent<VfxSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            if (_vfxSpawner != null)
            {
                _vfxSpawner.PlayKilledVFX();
            }
            restartButton.gameObject.SetActive(true);
        }
    }
}
