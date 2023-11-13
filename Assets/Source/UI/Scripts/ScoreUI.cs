using System.Collections;
using Source.Common.Scripts;
using TMPro;
using UnityEngine;

namespace Source.UI.Scripts
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text score;

        private void Start()
        {
            ApplyScoreValue();
        }

        public void ApplyScoreValue()
        {
            StartCoroutine(ApplyScoreValueNextFrame());
        }

        private IEnumerator ApplyScoreValueNextFrame()
        {
            yield return null;
            score.text = "Score: " + GameManager.Instance.Score;
        }
    }
}