using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public SceneManagement logic;

  
    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.Win();
    }
}
