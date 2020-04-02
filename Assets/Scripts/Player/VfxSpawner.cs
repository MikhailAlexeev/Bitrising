using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VfxSpawner : MonoBehaviour
{
    public string hittedTriggerName = "Hitted";
    public string killedTriggerName = "Killed";
    private Animator _animator;

    private void Awake()
    {
        _animator = transform.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _animator.SetTrigger(hittedTriggerName);
    }
    
    public void PlayKilledVFX()
    {
        _animator.SetTrigger(killedTriggerName);
    }
}
