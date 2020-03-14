using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSUnlocker : MonoBehaviour
{
    public int targetFramerate;
    void Awake()
    {
        Application.targetFrameRate = targetFramerate;
    }

   
}
