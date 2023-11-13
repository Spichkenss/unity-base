using Source.Core.Events;
using UnityEngine;

namespace Source.Common.Scripts
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField, Tooltip("The value that the player will receive when taking this item")]
        private int score = 10;

        [SerializeField] private IntEventChannel scoreChannel;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            scoreChannel.Invoke(score);
            Destroy(gameObject);
        }
    }
}