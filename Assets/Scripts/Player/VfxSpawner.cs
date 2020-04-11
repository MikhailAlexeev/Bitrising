using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxSpawner : MonoBehaviour
{
    public string hittedTriggerName = "Hitted";
    public string killedTriggerName = "Killed";
    public string jumpedTriggerName = "Jumped";
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

    public void PlayJumpVFX()
    {
        _animator.SetTrigger(jumpedTriggerName);
    }
}
