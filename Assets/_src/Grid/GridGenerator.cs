using _src.Grid.DebugThings;
using _src.Grid.Models;
using _src.Grid.Visual;
using UnityEngine;

namespace _src.Grid
{
    public class GridGenerator
    {
        private readonly GridCell[,] cells;
        private readonly GridData data;
        private readonly Transform gridParent;
        private readonly Transform gridVisualPrefab;


        public GridGenerator(
            GridData data,
            Transform gridVisualPrefab,
            Transform gridParent)
        {
            this.data = data;
            this.gridVisualPrefab = gridVisualPrefab;
            this.gridParent = gridParent;
            cells = new GridCell[data.width, data.height];
        }

        public GridCell[,] CreateCells()
        {
            for (var x = 0; x < data.width; x++)
            {
                for (var z = 0; z < data.height; z++)
                {
                    var position = new CellPosition(x, z);
                    CellVisualMono visual = SpawnVisual(
                        position.ToWorldPosition(data.cellSize),
                        gridVisualPrefab,
                        gridParent);
                    cells[x, z] = new GridCell(position, visual, CellStatus.Normal);
                }
            }

            return cells;
        }

        public void SpawnDebugObjects(Transform prefab, Transform parent)
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

        private CellVisualMono SpawnVisual(Vector3 worldPosition, Transform visualPrefab, Transform parent)
        {
            Transform visual = Object.Instantiate(visualPrefab, worldPosition, Quaternion.identity);
            visual.SetParent(parent, false);
            return visual.GetComponent<CellVisualMono>();
        }
    }
}