using UnityEngine;
using UnityEngine.UI;

namespace PacManMR
{
    public class HudPresenter : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text livesText;
        [SerializeField] private Text pelletsText;
        [SerializeField] private Text statusText;

        private void OnEnable()
        {
            if (GameManager.Instance != null) GameManager.Instance.StateChanged += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            if (GameManager.Instance != null) GameManager.Instance.StateChanged -= Refresh;
        }

        private void Refresh()
        {
            var game = GameManager.Instance;
            if (game == null) return;
            if (scoreText != null) scoreText.text = $"SCORE {game.Score:000000}";
            if (livesText != null) livesText.text = $"LIVES {game.Lives}";
            if (pelletsText != null) pelletsText.text = $"DOTS {game.RemainingPellets}";
            if (statusText != null) statusText.text = game.IsPowered ? $"POWER {game.PowerTimeRemaining:0}" : "COLLECT THE DOTS";
        }
    }
}
