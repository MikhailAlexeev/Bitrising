using Statics;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Killer : MonoBehaviour
    {
        public Button restartButton;

        private VfxSpawner _vfxSpawner;

        private void Start()
        {
            _vfxSpawner = GetComponent<VfxSpawner>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.GetTag(TagType.DeathZone))
                || other.gameObject.CompareTag(TagManager.GetTag(TagType.Enemy))
                || other.gameObject.CompareTag(TagManager.GetTag(TagType.Player)))
            {
                if (_vfxSpawner != null)
                {
                    _vfxSpawner.PlayKilledVFX();
                }

                if (gameObject.CompareTag(TagManager.GetTag(TagType.Player)))
                {
                    restartButton.gameObject.SetActive(true);
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

                }
            }
        }
    }
}