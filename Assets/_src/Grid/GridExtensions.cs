using _src.Grid.Models;
using UnityEngine;

namespace _src.Grid
{
    public static class GridExtensions
    {
        public static Vector3 ToWorldPosition(this CellPosition position, float cellSize)
        {
            return new Vector3(position.X, 0, position.Z) * cellSize;
        }

        public static (bool isInGrid, CellPosition position) ToGridPosition(this Vector3 worldPosition, GridData data)
        {
            int x = Mathf.RoundToInt(worldPosition.x / data.cellSize);
            int z = Mathf.RoundToInt(worldPosition.z / data.cellSize);

            var position = new CellPosition(x, z);

            bool isInGrid = IsInGrid(data, x, z);

            return (isInGrid, position);
        }

        private static bool IsInGrid(GridData data, int x, int z)
        {
            if (x < 0 || z < 0)
            {
                return false;
            }

            if (x >= data.width)
            {
                return false;
            }

            if (x >= data.height)
            {
                return false;
            }

            return true;
        }
    }
}