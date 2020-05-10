using ProcGen;
using Statics;
using UnityEngine;

namespace Behaviours
{
    public class PlatformBehaviour : MonoBehaviour
    {
        [SerializeField] private LevelSegmentSettingsData _levelSegmentSettingsData;
        private bool _isGenerate;

        public float GetBorder()
        {
            var child = transform.GetChild(transform.childCount - 1);
            var offsetX = child.GetComponent<Renderer>().bounds.extents.x;
            return child.localPosition.x + offsetX;
        }

        public void GenerateNewSegment()
        {
            _isGenerate = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagManager.GetTag(TagType.Player)))
            {
                _levelSegmentSettingsData.Generate();
            }
        }
    }
}