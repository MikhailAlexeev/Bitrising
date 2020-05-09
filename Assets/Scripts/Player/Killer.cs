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
            if (other.gameObject.CompareTag("DeathZone")
                || other.gameObject.CompareTag("Enemy")
                || other.gameObject.CompareTag("Player"))
            {
                if (_vfxSpawner != null)
                {
                    _vfxSpawner.PlayKilledVFX();
                }

                if (gameObject.CompareTag("Player"))
                {
                    restartButton.gameObject.SetActive(true);
                }
            }
        }
    }
}