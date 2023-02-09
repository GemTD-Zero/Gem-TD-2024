using _src.Grid.Models;
using _src.Player;
using UnityEngine;

namespace _src.Extensions
{
    public static class MouseHowerer
    {
        public static (bool isIngrid, GridPosition position) MoveObjectToMousePosition(
            MouseManagerMono mouseManager,
            SharedDataMono sharedData,
            Transform howerObject)
        {
            Vector3 worldPosition = mouseManager.GetMouseWorldPosition();
            (bool isInGrid, GridPosition gridPosition) = worldPosition.ToGridPosition(sharedData.grid);

            if (!isInGrid)
            {
                howerObject.SetDeactivated();
                return (false, new GridPosition());
            }

            howerObject.SetActivated();
            howerObject.transform.position = gridPosition.ToWorldPosition(sharedData.grid.cellSize);
            return (true, gridPosition);
        }
    }
}