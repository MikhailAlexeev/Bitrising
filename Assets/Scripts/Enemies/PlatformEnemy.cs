    using UnityEngine;
    public class PlatformEnemy : Enemy
    {
        
        public Collider2D Platform;
        private float _platformWidth;
        private bool _direction;

        private new void Start()
        {
            base.Start();
            _platformWidth = Platform.bounds.size.x;
        }

        private void Update()
        {

            var position = Platform.transform.position.x;
            var left = position - _platformWidth / 3;
            var right = position + _platformWidth / 3;
        
            if (transform.position.x < left)
                _direction = true;
            else if (transform.position.x > right)
                _direction = false;
            if (_direction) MoveRight();
            else MoveLeft();
        }
    }
