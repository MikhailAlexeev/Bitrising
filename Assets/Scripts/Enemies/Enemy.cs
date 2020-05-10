using Player;
using UnityEngine;

namespace Enemies
{
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
            _rb.AddForce(new Vector2(-moveForce, 0), ForceMode2D.Force);
        }

        public void MoveRight()
        {
            _rb.AddForce(new Vector2(moveForce, 0), ForceMode2D.Force);
        }
    }
}