using UnityEngine;

namespace _src.Grid
{
    public static class GridExtensions
    {
        public static Vector3 ToWorldPosition(this CellPosition position, float cellSize)
        {
            return new Vector3(position.X, 0, position.Z) * cellSize;
        }

        public static CellPosition ToGridPosition(this Vector3 worldPosition, float cellSize)
        {
            int x = Mathf.RoundToInt(worldPosition.x / cellSize);
            int z = Mathf.RoundToInt(worldPosition.z / cellSize);
            return new CellPosition(x, z);
        }
    }
}