using JetBrains.Annotations;
using ObservableCollections;
using UnityEngine;

namespace _src.Grid.GridManager
{
    [UsedImplicitly]
    public class GridManagerService
    {
        private readonly GridManagerMono mono;
        private readonly SharedDataMono sharedData;
        private GridCell currentHoveredCell;

        public GridManagerService(
            GridManagerMono mono,
            SharedDataMono sharedData)
        {
            this.mono = mono;
            this.sharedData = sharedData;
            mono.selectedCells = new ObservableList<GridCell>();
        }

        public void OnClicked(Vector3 mousePosition)
        {
            (bool isInGrid, GridCell cell) = GetCell(mousePosition);

            if (!isInGrid)
            {
                return;
            }

            if (cell.Status == CellStatus.Selected)
            {
                mono.selectedCells.Remove(cell);
                cell.Unselect();
            }
            else if (cell.Status is CellStatus.MouseHover or CellStatus.Normal)
            {
                mono.selectedCells.Add(cell);
                cell.Select();
            }
        }

        public void OnMouseOver(Vector3 mousePosition)
        {
            (bool isInGrid, GridCell newHoveredCell) = GetCell(mousePosition);

            if (!isInGrid)
            {
                return;
            }

            if (newHoveredCell == currentHoveredCell)
            {
                return;
            }

            if (newHoveredCell.Status == CellStatus.Normal)
            {
                newHoveredCell.MouseHover();
            }

            UnselectCurrentHovered();
            currentHoveredCell = newHoveredCell;
        }

        private void UnselectCurrentHovered()
        {
            if (currentHoveredCell is not { Status: CellStatus.MouseHover })
            {
                return;
            }

            currentHoveredCell.Unselect();
        }

        private (bool isInGrid, GridCell cell) GetCell(Vector3 worldPosition)
        {
            (bool isInGrid, CellPosition position) = worldPosition.ToGridPosition(sharedData.grid);

            if (!isInGrid)
            {
                return (false, null);
            }

            return (true, mono.Cells[position.X, position.Z]);
        }
    }
}