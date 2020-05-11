using System;
using Enums;
using UnityEngine;

namespace Structs
{
    [Serializable]
    public struct TrapData
    {
        public TrapType type;
        [Range(0, 100)] public int creationChance;
    }
}