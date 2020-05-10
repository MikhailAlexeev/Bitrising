    using System;
    using UnityEngine;
    namespace Behaviours
    {
        public class PlatformBehaviour : MonoBehaviour
        {
            private bool _isGenerate;
            public float GetBorder()
            {
                var child = transform.GetChild(transform.childCount-1);
                var offsetX = child.GetComponent<Renderer>().bounds.extents.x;
                return child.localPosition.x + offsetX;
            }

            public void GenerateNewSegment()
            {
                _isGenerate = true;
            }

            private void OnTriggerEnter(Collider other)
            {
                throw new NotImplementedException();
            }
        }
    }
