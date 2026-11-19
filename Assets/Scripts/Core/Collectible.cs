using UnityEngine;

namespace PacManMR
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private bool isPowerPellet;
        public void Configure(bool power) => isPowerPellet = power;

        private void Update()
        {
            transform.Rotate(Vector3.up, 90f * Time.deltaTime, Space.World);
        }

        public void Collect()
        {
            if (GameManager.Instance != null) GameManager.Instance.Collect(isPowerPellet);
            Destroy(gameObject);
        }
    }
}
