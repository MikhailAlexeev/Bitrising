using System;
using Enums;
using NaughtyAttributes;
using UnityEngine;

namespace Structs
{
    [Serializable]
    public struct PlatformData
    {
        public PlatformType type;
        [MinMaxSlider(-5, 5)] public Vector2 randomHeight;
        [MinMaxSlider(0, 5)] public Vector2 randomMargin;
        public TrapData trapData;
    }
}