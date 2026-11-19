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
        [SerializeField] private Material houseMaterial;
        [SerializeField] private Material gateMaterial;
        [SerializeField] private float originHeight;
        private void Start() => Build();
        public void Build()
        {
            if (mazeRoot == null) mazeRoot = transform;
            for (int i = mazeRoot.childCount - 1; i >= 0; i--)
            {
                GameObject child = mazeRoot.GetChild(i).gameObject;
                if (Application.isPlaying) Destroy(child); else DestroyImmediate(child);
            }
            foreach (var cell in MazeDefinition.Cells())
            {
                Vector3 p = MazeDefinition.CellToWorld(cell.row, cell.col, transform.position);
                p.y = transform.position.y + originHeight;
                switch (cell.value)
                {
                    case '#': CreateWallTile(p); break;
                    case '.': CreatePickup(p, false); break;
                    case 'o': CreatePickup(p, true); break;
                    case 'H': CreateHouseTile(p); break;
                    case '-': CreateGate(p); break;
                }
            }
            Vector3 player = MazeDefinition.CellToWorld(MazeDefinition.PlayerStart.x, MazeDefinition.PlayerStart.y, transform.position);
            if (playerStart != null) playerStart.position = player + Vector3.up * 1.6f;
            foreach (Vector2 start in MazeDefinition.GhostStarts)
                CreateGhost(MazeDefinition.CellToWorld(start.x, start.y, transform.position) + Vector3.up * 0.8f);
        }
        private void CreateWallTile(Vector3 p)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Maze Wall Tile"; go.transform.SetParent(mazeRoot, true);
            go.transform.position = p + Vector3.up * (MazeDefinition.WallHeight * 0.5f);
            go.transform.localScale = new Vector3(MazeDefinition.TileSize, MazeDefinition.WallHeight, MazeDefinition.TileSize);
            if (wallMaterial != null) go.GetComponent<Renderer>().sharedMaterial = wallMaterial;
        }
        private void CreateHouseTile(Vector3 p)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Ghost House Floor"; go.transform.SetParent(mazeRoot, true);
            go.transform.position = p + Vector3.down * 0.015f;
            go.transform.localScale = new Vector3(MazeDefinition.TileSize, 0.03f, MazeDefinition.TileSize);
            if (houseMaterial != null) go.GetComponent<Renderer>().sharedMaterial = houseMaterial;
            RemoveCollider(go);
        }
        private void CreateGate(Vector3 p)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Ghost House Gate"; go.transform.SetParent(mazeRoot, true);
            go.transform.position = p + Vector3.up * 0.72f;
            go.transform.localScale = new Vector3(MazeDefinition.TileSize, 0.08f, 0.06f);
            if (gateMaterial != null) go.GetComponent<Renderer>().sharedMaterial = gateMaterial;
        }
        private void CreatePickup(Vector3 p, bool power)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = power ? "Power Pellet" : "Pellet"; go.transform.SetParent(mazeRoot, true);
            go.transform.position = p + Vector3.up * 0.85f;
            go.transform.localScale = Vector3.one * (power ? 0.28f : 0.11f);
            go.GetComponent<SphereCollider>().isTrigger = true;
            RemoveRigidbody(go);
            go.AddComponent<Collectible>().Configure(power);
            Material mat = power ? powerPelletMaterial : pelletMaterial;
            if (mat != null) go.GetComponent<Renderer>().sharedMaterial = mat;
        }
        private void CreateGhost(Vector3 p)
        {
            GameObject go;
            if (ghostPrefab != null) go = Instantiate(ghostPrefab, p, Quaternion.identity, mazeRoot);
            else
            {
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.transform.SetParent(mazeRoot, true); go.transform.position = p;
                go.transform.localScale = new Vector3(0.65f, 0.8f, 0.65f);
                go.AddComponent<GhostController>();
            }
            go.name = "Ghost";
        }
        private static void RemoveCollider(GameObject go)
        {
            Collider c = go.GetComponent<Collider>(); if (c == null) return;
            if (Application.isPlaying) Destroy(c); else DestroyImmediate(c);
        }
        private static void RemoveRigidbody(GameObject go)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>(); if (rb == null) return;
            if (Application.isPlaying) Destroy(rb); else DestroyImmediate(rb);
        }
    }
}