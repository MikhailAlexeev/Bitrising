using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int moveForce;
    public Joystick joystick;
    public Button joystickButton;
    [Header("Jump controls")] public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    [Header("Jump Punch Effect")] public Vector2 scale;
    public float duration;
    public float elasticity;
    [Header("UI")] public Button restartButton;

    private TriggerDetector triggerDetector;


    private Rigidbody2D rb;
    private float horizontalInput;
    private bool jumpInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggerDetector = GetComponentInChildren<TriggerDetector>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);

        JoystickMove();
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
        Jump();
        JumpAmplifier();
    }

    void MoveHorizontal()
    {
        rb.velocity += new Vector2(horizontalInput, 0) * (moveForce * Time.deltaTime);
    }

    void JoystickMove()
    {
        rb.AddForce(new Vector2(joystick.Horizontal * moveForce, 0.0f));
    }

    public void JoystickPressed()
    {
        jumpInput = true;
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.GetComponentInParent<Platform>() != null)
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            restartButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.GetComponentInParent<Platform>() != null)
        {
            transform.SetParent(null);
        }
    }


    void Jump()
    {
        if (jumpInput)
        {
            if (triggerDetector.InTrigger)
            {
                JumpPunch();
                rb.AddForce(Vector2.up * jumpForce);
                transform.SetParent(null);
            }
        }
    }

    void JumpPunch()
    {
        transform.DOPunchScale(scale, duration, elasticity: elasticity);
    }

    void JumpAmplifier()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);

            // Get this to work with joystick button
            // else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            // {
            //     rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
            // }
        }
    }
}