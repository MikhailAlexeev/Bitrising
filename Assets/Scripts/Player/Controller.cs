using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller : MonoBehaviour
    {
        public int moveForce;
        [Header("Joystick")]
        public Joystick moveStick;
        public Button button;
        [Header("Jump controls")] public float jumpForce;
        public float fallMultiplier;
        public float lowJumpMultiplier;
        [Header("Jump Punch Effect")] public Vector2 scale;
        public float duration;
        public float elasticity;


        private TriggerDetector _triggerDetector;
        private VfxSpawner _vfxSpawner;

        private Rigidbody2D _rb;
        private float _horizontalInput;
        private bool _jumpInput;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _triggerDetector = GetComponentInChildren<TriggerDetector>();
            _vfxSpawner = GetComponent<VfxSpawner>();
        }

        void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _jumpInput = Input.GetKeyDown(KeyCode.Space);

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
            _rb.velocity += new Vector2(_horizontalInput, 0) * (moveForce * Time.deltaTime);
        }

        void JoystickMove()
        {
            _rb.AddForce(new Vector2(moveStick.Horizontal * moveForce, 0.0f));
        }

        public void JoystickPressed()
        {
            _jumpInput = true;
            Jump();
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

        void Jump()
        {
            if (_jumpInput)
            {
                if (_triggerDetector.inTrigger)
                {
                    _vfxSpawner.PlayJumpVFX();
                    JumpPunch();
                    _rb.AddForce(Vector2.up * jumpForce);
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
            if (_rb.velocity.y < 0)
            {
                _rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
           
            }
            
            // Как это сделать с кнопкой джойстика?
            // else if (rb.velocity.y > 0)
            // {
            //     rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
            // }
        }
    }
}