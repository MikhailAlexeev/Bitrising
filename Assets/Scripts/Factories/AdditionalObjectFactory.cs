using System;
using UnityEngine;
using Behaviours;
using Enums;
using Statics;
using Object = UnityEngine.Object;

namespace Factories
{
    public class AdditionalObjectFactory
    {
        private GameObject _saw;
        private GameObject _spike;


        public GameObject GetPlatform(PlatformType type)
        {
            GameObject prefab;
            switch (type)
            {
                case PlatformType.Short:
                    prefab = GetShort();
                    break;
                case PlatformType.Medium:
                    prefab = GetMedium();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return Object.Instantiate(prefab);
        }

        private GameObject GetShort()
        {
            if (!_saw)
            {
                _saw = Resources.Load<GameObject>(AssetsPaths.Platforms[PlatformType.Short]);
            }

            return _saw;
        }

        private GameObject GetMedium()
        {
            if (!_spike)
            {
                _spike = Resources.Load<GameObject>(AssetsPaths.Platforms[PlatformType.Medium]);
            }

            return _spike;
        }
    }
}