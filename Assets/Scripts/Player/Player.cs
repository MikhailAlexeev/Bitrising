﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int moveForce;
    public Joystick joystick;
    [Header("Jump controls")] 
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    [Header("Jump Punch Effect")] 
    public Vector2 scale;
    public float duration;
    public float elasticity;
    
    private TriggerDetector triggerDetector;


    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggerDetector = GetComponentInChildren<TriggerDetector>();
    }

    void Update()
    {
        Controls();
        JoystickMove();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }
        // Get this to work with joystick button
        // else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        // {
        //     rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        // }
    }

    void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity += new Vector2(horizontalInput, 0) * (moveForce * Time.deltaTime);
    }

    void JoystickMove()
    {
        rb.AddForce(new Vector2(joystick.Horizontal * moveForce, 0.0f));
    }

    void Jump()
    {
        if (triggerDetector.InTrigger)
        {
            JumpPunch();
            rb.AddForce(Vector2.up * jumpForce);
            transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.GetComponentInParent<Platform>() != null)
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.GetComponentInParent<Platform>() != null)
        {
            transform.SetParent(null);
        }
    }

    void Controls()
    {
        MoveHorizontal();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void JumpPunch()
    {
        transform.DOPunchScale(scale , duration, elasticity:elasticity);
    }
}