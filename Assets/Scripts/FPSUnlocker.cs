using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSUnlocker : MonoBehaviour
{
    public int targetFramerate;
    // Start is called before the first frame update
    void Start()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = targetFramerate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
