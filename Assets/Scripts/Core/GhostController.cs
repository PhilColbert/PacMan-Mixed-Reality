using UnityEngine;

namespace PacManMR
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float chaseSpeed = 1.05f;
        [SerializeField] private float roamSpeed = 0.65f;
        [SerializeField] private float retargetSeconds = 3f;
        private Vector3 roamTarget;
        private float retargetAt;

        private void Start()
        {
            var collector = FindFirstObjectByType<PlayerCollector>();
            if (collector != null) player = collector.transform;
            PickRoamTarget();
        }

        private void Update()
        {
            if (player == null)
            {
                var found = FindFirstObjectByType<PlayerCollector>();
                if (found != null) player = found.transform;
                else return;
            }

            bool chase = Vector3.Distance(transform.position, player.position) < 7f;
            Vector3 target = chase ? player.position : roamTarget;
            target.y = transform.position.y;
            Vector3 direction = target - transform.position;
            if (!chase && Time.time >= retargetAt) PickRoamTarget();
            if (direction.sqrMagnitude > 0.04f)
            {
                transform.position += direction.normalized * (chase ? chaseSpeed : roamSpeed) * Time.deltaTime;
                transform.forward = Vector3.Lerp(transform.forward, direction.normalized, 5f * Time.deltaTime);
            }
        }

        private void PickRoamTarget()
        {
            roamTarget = transform.position + new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f));
            retargetAt = Time.time + retargetSeconds;
        }

        public void TouchPlayer()
        {
            if (GameManager.Instance == null) return;
            if (GameManager.Instance.IsPowered) Destroy(gameObject);
            else GameManager.Instance.GhostHit();
        }
    }
}
