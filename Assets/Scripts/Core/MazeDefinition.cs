using System.Collections.Generic;
using UnityEngine;
namespace PacManMR
{
    /// <summary>Canonical original Pac-Man arcade playfield, 28 columns by 31 rows.</summary>
    public static class MazeDefinition
    {
        public const int Width = 28;
        public const int Height = 31;
        public const float TileSize = 30f / 31f;
        public const float WallHeight = 1.5f;
        public const float WallThickness = TileSize;
        // # wall, . dot, o energizer, space open, - ghost-house door, H house.
        // Preserve significant spaces in the side tunnel.
        public static readonly string[] Rows =
        {
            "############################",
            "#............##............#",
            "#.####.#####.##.#####.####.#",
            "#o####.#####.##.#####.####o#",
            "#.####.#####.##.#####.####.#",
            "#..........................#",
            "#.####.##.########.##.####.#",
            "#.####.##.########.##.####.#",
            "#......##....##....##......#",
            "######.##### ## #####.######",
            "######.##### ## #####.######",
            "######.##          ##.######",
            "######.## ###--### ##.######",
            "######.## #HHHHHH# ##.######",
            "      .   #HHHHHH#   .      ",
            "######.## #HHHHHH# ##.######",
            "######.## ######## ##.######",
            "######.##          ##.######",
            "######.## ######## ##.######",
            "######.## ######## ##.######",
            "#............##............#",
            "#.####.#####.##.#####.####.#",
            "#.####.#####.##.#####.####.#",
            "#o..##.......  .......##..o#",
            "###.##.##.########.##.##.###",
            "###.##.##.########.##.##.###",
            "#......##....##....##......#",
            "#.##########.##.##########.#",
            "#.##########.##.##########.#",
            "#..........................#",
            "############################"
        };
        public static readonly Vector2 PlayerStart = new Vector2(14f, 23f);
        public static readonly Vector2[] GhostStarts =
        {
            new Vector2(14f, 11.5f), new Vector2(14f, 14.5f),
            new Vector2(12f, 14.5f), new Vector2(16f, 14.5f)
        };
        public static Vector3 CellToWorld(int row, int col, Vector3 origin) => CellToWorld(col, row, origin);
        public static Vector3 CellToWorld(float x, float y, Vector3 origin)
        {
            float width = Width * TileSize, depth = Height * TileSize;
            return origin + new Vector3((x + 0.5f) * TileSize - width * 0.5f, 0f,
                depth * 0.5f - (y + 0.5f) * TileSize);
        }
        public static IEnumerable<(int row, int col, char value)> Cells()
        {
            for (int r = 0; r < Rows.Length; r++)
                for (int c = 0; c < Rows[r].Length; c++)
                    yield return (r, c, Rows[r][c]);
        }
    }
}