using UnityEngine;

namespace PacManMR
{
    /// <summary>Attach to XR camera/head transform. Uses proximity rather than requiring a physical collider.</summary>
    public class PlayerCollector : MonoBehaviour
    {
        [SerializeField] private float collectionRadius = 0.48f;
        [SerializeField] private float ghostContactRadius = 0.75f;
        [SerializeField] private float scanInterval = 0.08f;
        private float nextScan;

        private void Update()
        {
            if (Time.time < nextScan) return;
            nextScan = Time.time + scanInterval;

            foreach (var item in FindObjectsByType<Collectible>(FindObjectsSortMode.None))
                if (Vector3.Distance(transform.position, item.transform.position) <= collectionRadius)
                    item.Collect();

            foreach (var ghost in FindObjectsByType<GhostController>(FindObjectsSortMode.None))
                if (Vector3.Distance(transform.position, ghost.transform.position) <= ghostContactRadius)
                    ghost.TouchPlayer();
        }
    }
}
