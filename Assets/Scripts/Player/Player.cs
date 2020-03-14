using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int moveForce;

    public Joystick joystick;
    [Header("Jump controls")] public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
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
        // Set to work with joystick button
        // else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        // {
        //     rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        // }
    }

    void MoveLeft()
    {
        rb.velocity += Vector2.left * (moveForce * Time.deltaTime);
    }

    void MoveRight()
    {
        rb.velocity += Vector2.right * (moveForce * Time.deltaTime);
    }

    void JoystickMove()
    {
        rb.AddForce(new Vector2(joystick.Horizontal * moveForce, 0.0f));
    }

    void Jump()
    {
        if (triggerDetector.InTrigger)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    void Controls()
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