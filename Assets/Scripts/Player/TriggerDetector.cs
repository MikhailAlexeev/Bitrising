using UnityEngine;

namespace Player
{
    public class TriggerDetector : MonoBehaviour
    {
        public bool inTrigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            inTrigger = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            inTrigger = false;
        }
    }
}
