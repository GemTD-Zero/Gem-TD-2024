using _src.Grid.Debug;
using UnityEngine;

namespace _src.Grid
{
    public class GridGenerator
    {
        private readonly GridCell[,] cells;
        private readonly float cellSize;
        private readonly int height;
        private readonly int width;

        public GridGenerator(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            cells = new GridCell[width, height];
        }

        public GridCell[,] CreateCells()
        {
            for (var x = 0; x < width; x++)
            {
                for (var z = 0; z < height; z++)
                {
                    cells[x, z] = GenerateCell(x, z);
                }
            }

            return cells;
        }

        public void SpawnDebugObjects(Transform prefab, Transform parent = null)
        {
            for (var x = 0; x < width; x++)
            {
                for (var z = 0; z < height; z++)
                {
                    var position = new CellPosition(x, z);
                    Transform debug = Object.Instantiate(prefab, position.ToWorldPosition(cellSize), Quaternion.identity);
                    debug.SetParent(parent, false);
                    var component = debug.GetComponent<GridDebugMono>();
                    component.SetGridCell(cells[x, z]);
                }
            }
        }

        private static GridCell GenerateCell(int x, int z)
        {
            var positoin = new CellPosition(x, z);
            return new GridCell(positoin);
        }
    }
}