using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int moveForce;
    public int jumpForce;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }

    public void MoveLeft()
    {
        _rb.AddForce(Vector2.left * (moveForce * Time.deltaTime), ForceMode2D.Force);
    }
    
    public void MoveRight()
    {
        _rb.AddForce(Vector2.right * (moveForce * Time.deltaTime), ForceMode2D.Force);
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * (jumpForce * Time.deltaTime), ForceMode2D.Force);
    }

    public void PlayerControl()
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
