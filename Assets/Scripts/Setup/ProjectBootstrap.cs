using UnityEngine;

namespace PacManMR
{
    /// <summary>Optional quick-start component. Add to an empty scene object and assign references in Inspector.</summary>
    public class ProjectBootstrap : MonoBehaviour
    {
        [SerializeField] private MazeBuilder mazeBuilder;
        [SerializeField] private Transform xrHeadCamera;

        private void Awake()
        {
            if (FindFirstObjectByType<GameManager>() == null)
                new GameObject("GameManager").AddComponent<GameManager>();

            if (xrHeadCamera != null && xrHeadCamera.GetComponent<PlayerCollector>() == null)
                xrHeadCamera.gameObject.AddComponent<PlayerCollector>();
        }

        private void Start()
        {
            if (mazeBuilder != null) mazeBuilder.Build();
            else Debug.LogWarning("Assign a MazeBuilder in the Inspector before starting the game.");
        }
    }
}
