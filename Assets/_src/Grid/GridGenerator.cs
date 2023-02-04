using _src.Grid.Debug;
using _src.Grid.Models;
using UnityEngine;

namespace _src.Grid
{
    public class GridGenerator
    {
        private readonly GridCell[,] cells;
        private readonly GridData data;

        public GridGenerator(GridData data)
        {
            this.data = data;
            cells = new GridCell[data.width, data.height];
        }

        public GridCell[,] CreateCells()
        {
            for (var x = 0; x < data.width; x++)
            {
                for (var z = 0; z < data.height; z++)
                {
                    cells[x, z] = GenerateCell(x, z);
                }
            }

            return cells;
        }

        public void SpawnDebugObjects(Transform prefab, Transform parent = null)
        {
            for (var x = 0; x < data.width; x++)
            {
                for (var z = 0; z < data.height; z++)
                {
                    var position = new CellPosition(x, z);
                    Transform debug = Object.Instantiate(prefab, position.ToWorldPosition(data.cellSize), Quaternion.identity);
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