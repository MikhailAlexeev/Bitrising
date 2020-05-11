using System;
using UnityEngine;
using Behaviours;
using Enums;
using Statics;
using Object = UnityEngine.Object;

namespace Factories
{
    public sealed class PlatformFactory
    {
        private PlatformBehaviour _short;
        private PlatformBehaviour _medium;
        private PlatformBehaviour _long;


        public PlatformBehaviour GetPlatform(PlatformType type)
        {
            PlatformBehaviour prefab;
            switch (type)
            {
                case PlatformType.Short:
                    prefab = GetShort();
                    break;
                case PlatformType.Medium:
                    prefab = GetMedium();
                    break;
                case PlatformType.Long:
                    prefab = GetLong();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return Object.Instantiate(prefab);
        }

        private PlatformBehaviour GetShort()
        {
            if (!_short)
            {
                _short = Resources.Load<PlatformBehaviour>(AssetsPaths.Platforms[PlatformType.Short]);
            }

            return _short;
        }

        private PlatformBehaviour GetMedium()
        {
            if (!_medium)
            {
                _medium = Resources.Load<PlatformBehaviour>(AssetsPaths.Platforms[PlatformType.Medium]);
            }

            return _medium;
        }

        private PlatformBehaviour GetLong()
        {
            if (!_long)
            {
                _long = Resources.Load<PlatformBehaviour>(AssetsPaths.Platforms[PlatformType.Long]);
            }

            return _long;
        }
    }
}