using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
   public float fallMultiplier;
   public float lowJumpMultiplier;

   private Rigidbody2D rb;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      if (rb.velocity.y < 0)
      {
         rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
      }
   }
}
