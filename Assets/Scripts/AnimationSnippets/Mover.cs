using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 movement;
    [SerializeField] private float speed;
    private Vector3 _startPos;
    private void Start()
    {
        _startPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = _startPos + movement * (Mathf.Sin(Time.time * speed));
    }
}