using UnityEngine;
using System;

namespace PacManMR
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public int Score { get; private set; }
        public int Lives { get; private set; } = 3;
        public int RemainingPellets { get; private set; }
        public bool IsPowered { get; private set; }
        public float PowerTimeRemaining { get; private set; }
        public event Action StateChanged;
        [SerializeField] private float powerDuration = 8f;

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            RemainingPellets = CountPelletsInLayout();
        }

        private void Update()
        {
            if (IsPowered)
            {
                PowerTimeRemaining -= Time.deltaTime;
                if (PowerTimeRemaining <= 0f) { IsPowered = false; PowerTimeRemaining = 0f; StateChanged?.Invoke(); }
            }
        }

        public void Collect(bool power)
        {
            Score += power ? 50 : 10;
            RemainingPellets = Mathf.Max(0, RemainingPellets - 1);
            if (power) { IsPowered = true; PowerTimeRemaining = powerDuration; }
            StateChanged?.Invoke();
            if (RemainingPellets == 0) Debug.Log("Maze cleared!");
        }

        public void GhostHit()
        {
            if (IsPowered) { Score += 200; StateChanged?.Invoke(); return; }
            Lives = Mathf.Max(0, Lives - 1);
            StateChanged?.Invoke();
            if (Lives == 0) Debug.Log("Game over!");
        }

        private static int CountPelletsInLayout()
        {
            int count = 0;
            foreach (var cell in MazeDefinition.Cells())
                if (cell.value == '.' || cell.value == 'o') count++;
            return count;
        }
    }
}
