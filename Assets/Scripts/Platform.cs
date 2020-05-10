using System;
using System.Collections;
using Player;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public int currentPoint = 0;
    public Animator animator;
    public string landedStateName = "Landed";

    private Transform _from;
    private Transform _to;
    private TriggerDetector _triggerDetector;

    private const float DIST_EPSILON = 0.001f;


    private void Awake()
    {
        SetFromTo();
        _triggerDetector = GetComponentInChildren<TriggerDetector>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _to.position, Time.deltaTime * speed);

        if (ReachedFinish())
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
            SetFromTo();
        }

        
    }

    private void SetFromTo()
    {
        _from = points[currentPoint];
        _to = currentPoint + 1 >= points.Length ? points[0] : points[currentPoint + 1];
    }

    private bool ReachedFinish()
    {
        return Vector2.Distance(transform.position, _to.position) < DIST_EPSILON;
    }

    // Make this work with Player parenting to Platform
    // What to do with player size?
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (_triggerDetector.inTrigger)
    //     {
    //         animator.Play(landedStateName);
    //         Transform player = transform.Find("Player");
    //         player.localScale = new Vector3(0.3f,0.5f,0.1f);
    //     }
    // }

}