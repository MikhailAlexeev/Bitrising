using UnityEngine;

public class PlatformEnemy : Enemy
{
    public Collider2D platform;
    private float _platformWidth;
    private bool _rightDirection;

    private new void Start()
    {
        base.Start();
        _platformWidth = platform.bounds.size.x;
    }

    private void Update()
    {
        var position = platform.transform.position.x;
        var left = position - _platformWidth / 3;
        var right = position + _platformWidth / 3;

        if (transform.position.x < left)
        {
            _rightDirection = true;
        }
        else if (transform.position.x > right)
        {
            _rightDirection = false;
        }

        if (_rightDirection)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }
}