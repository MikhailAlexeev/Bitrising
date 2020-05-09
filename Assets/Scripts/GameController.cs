﻿using ProcGen;
using UnityEngine;

public sealed class GameController : MonoBehaviour
{
   [SerializeField] private LevelSegmentSettingsData levelSegmentSettingsData;

   private void Awake()
   {
      levelSegmentSettingsData.Generate();
   }
}
