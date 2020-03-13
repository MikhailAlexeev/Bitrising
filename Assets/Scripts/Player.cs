﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int moveForce;
    public int jumpForce;

    private Rigidbody2D rb;
    private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    public void MoveLeft()
    {
        rb.AddForce(new Vector2(-moveForce, 0), ForceMode2D.Force);
    }

    public void MoveRight()
    {
        rb.AddForce(new Vector2(moveForce, 0), ForceMode2D.Force);
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
    }

    public void Controls()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}