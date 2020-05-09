using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsUnlocker : MonoBehaviour
{
    public int targetFramerate;

    private void Awake()
    {
        Application.targetFrameRate = targetFramerate;
    }

   
}
