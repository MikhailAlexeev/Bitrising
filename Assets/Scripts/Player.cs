using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int moveForce;
    public int jumpForce;
    public Joystick _joystick;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
        JoystickMove();
    }

    public void MoveLeft()
    {
        _rb.AddForce(new Vector2(-moveForce, 0.0f), ForceMode2D.Force);
    }

    public void MoveRight()
    {
        _rb.AddForce(new Vector2(moveForce, 0), ForceMode2D.Force);
    }

    public void JoystickMove()
    {
        _rb.AddForce(new Vector2(_joystick.Horizontal*moveForce,0.0f));
    }
    public void Jump()
    {
        _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
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