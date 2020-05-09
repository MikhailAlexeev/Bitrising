
    using UnityEngine;

    namespace Behaviours
    {
        public class PlatformBehaviour : MonoBehaviour
        {
            public float GetBorder()
            {
                var child = transform.GetChild(transform.childCount-1);
                var offsetX = child.GetComponent<Renderer>().bounds.extents.x;
                return transform.localPosition.x + offsetX;
            }
        }
    }
