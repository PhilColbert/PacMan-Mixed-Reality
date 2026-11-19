using UnityEngine;

namespace PacManMR
{
    public class MazeBuilder : MonoBehaviour
    {
        [SerializeField] private Transform mazeRoot;
        [SerializeField] private Transform playerStart;
        [SerializeField] private GameObject ghostPrefab;
        [SerializeField] private Material wallMaterial;
        [SerializeField] private Material pelletMaterial;
        [SerializeField] private Material powerPelletMaterial;
        [SerializeField] private float originHeight;

        private void Start() => Build();

        public void Build()
        {
            if (mazeRoot == null) mazeRoot = transform;
            foreach (Transform child in mazeRoot) Destroy(child.gameObject);

            foreach (var cell in MazeDefinition.Cells())
            {
                Vector3 position = MazeDefinition.CellToWorld(cell.row, cell.col, transform.position);
                position.y = transform.position.y + originHeight;
                switch (cell.value)
                {
                    case '#': CreateWall(position); break;
                    case '.': CreatePickup(position, false); break;
                    case 'o': CreatePickup(position, true); break;
                    case 'P':
                        if (playerStart != null) playerStart.position = position + Vector3.up * 1.6f;
                        break;
                    case 'G': CreateGhost(position); break;
                }
            }
        }

        private void CreateWall(Vector3 floorPosition)
        {
            var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.name = "Maze Wall";
            wall.transform.SetParent(mazeRoot, true);
            wall.transform.position = floorPosition + Vector3.up * (MazeDefinition.WallHeight * 0.5f);
            wall.transform.localScale = new Vector3(MazeDefinition.TileSize, MazeDefinition.WallHeight, MazeDefinition.WallThickness);
            if (wallMaterial != null) wall.GetComponent<Renderer>().sharedMaterial = wallMaterial;
            wall.layer = LayerMask.NameToLayer("Default");
        }

        private void CreatePickup(Vector3 floorPosition, bool power)
        {
            var pickup = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pickup.name = power ? "Power Pellet" : "Pellet";
            pickup.transform.SetParent(mazeRoot, true);
            pickup.transform.position = floorPosition + Vector3.up * 0.85f;
            float diameter = power ? 0.28f : 0.11f;
            pickup.transform.localScale = Vector3.one * diameter;
            var collider = pickup.GetComponent<SphereCollider>();
            collider.isTrigger = true;
            Destroy(pickup.GetComponent<Rigidbody>());
            var collectible = pickup.AddComponent<Collectible>();
            collectible.Configure(power);
            var renderer = pickup.GetComponent<Renderer>();
            if (power ? powerPelletMaterial != null : pelletMaterial != null)
                renderer.sharedMaterial = power ? powerPelletMaterial : pelletMaterial;
        }

        private void CreateGhost(Vector3 floorPosition)
        {
            GameObject ghost;
            if (ghostPrefab != null) ghost = Instantiate(ghostPrefab, floorPosition + Vector3.up * 0.8f, Quaternion.identity, mazeRoot);
            else
            {
                ghost = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ghost.transform.SetParent(mazeRoot, true);
                ghost.transform.position = floorPosition + Vector3.up * 0.8f;
                ghost.transform.localScale = new Vector3(0.65f, 0.8f, 0.65f);
                ghost.AddComponent<GhostController>();
            }
            ghost.name = "Ghost";
        }
    }
}
