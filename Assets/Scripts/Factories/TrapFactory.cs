using System;
using UnityEngine;
using Enums;
using Statics;
using Object = UnityEngine.Object;

namespace Factories
{
    public class TrapFactory
    {
        private GameObject _spike;
        private GameObject _saw;


        public GameObject GetTrap(TrapType type)
        {
            GameObject prefab;
            switch (type)
            {
                case TrapType.Spike:
                    prefab = GetSpike();
                    break;
                case TrapType.Saw:
                    prefab = GetSaw();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return Object.Instantiate(prefab);
        }

        private GameObject GetSpike()
        {
            if (!_spike)
            {
                _spike = Resources.Load<GameObject>(AssetsPaths.Traps[TrapType.Spike]);
            }

            return _spike;
        }

        private GameObject GetSaw()
        {
            if (!_saw)
            {
                _saw = Resources.Load<GameObject>(AssetsPaths.Traps[TrapType.Saw]);
            }

            return _saw;
        }
    }
}