﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveForce;

    private TriggerDetector _triggerDetector;
    private VfxSpawner _vfxSpawner;
    private Rigidbody2D _rb;
    
    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _triggerDetector = GetComponent<TriggerDetector>();
        _vfxSpawner = GetComponent<VfxSpawner>();
    }
    
    public void MoveLeft()
    {
        //if (triggerDetector.InTrigger)
        _rb.AddForce(new Vector2(-moveForce, 0), ForceMode2D.Force);
    }

    public void MoveRight()
    {
        //if (triggerDetector.InTrigger)
        _rb.AddForce(new Vector2(moveForce, 0), ForceMode2D.Force);
    }
}