using System.Collections.Generic;
using UnityEngine;

namespace PacManMR
{
    /// <summary>Human-scale 15x15 adaptation. '#' wall, '.' pellet, 'o' power pellet, 'P' spawn, 'G' ghost spawn, space corridor.</summary>
    public static class MazeDefinition
    {
        public const float TileSize = 1.2f;
        public const float WallHeight = 1.5f;
        public const float WallThickness = 0.12f;

        public static readonly string[] Rows =
        {
            "###############",
            "#P....#...#...G#",
            "#.##..#.#.#.##.#",
            "#o##....#....#o#",
            "#.####.###.##..#",
            "#......#......#",
            "###.##.#.##.###",
            "  #....G....#  ",
            "###.##...##.###",
            "#......#......#",
            "#.##.#####.##..#",
            "#o...#...#....o#",
            "#.##.#.#.#.##..#",
            "#G...#...#....G#",
            "###############"
        };

        public static Vector3 CellToWorld(int row, int col, Vector3 origin)
        {
            float width = Rows[0].Length * TileSize;
            float depth = Rows.Length * TileSize;
            return origin + new Vector3((col + 0.5f) * TileSize - width * 0.5f, 0f,
                                        (row + 0.5f) * TileSize - depth * 0.5f);
        }

        public static IEnumerable<(int row, int col, char value)> Cells()
        {
            for (int r = 0; r < Rows.Length; r++)
                for (int c = 0; c < Rows[r].Length; c++)
                    yield return (r, c, Rows[r][c]);
        }
    }
}
