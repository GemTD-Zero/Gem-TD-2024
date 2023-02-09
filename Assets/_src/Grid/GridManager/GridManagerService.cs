using _src.Extensions;
using _src.Grid.Models;
using JetBrains.Annotations;
using ObservableCollections;
using UnityEngine;

namespace _src.Grid.GridManager
{
    [UsedImplicitly]
    public class GridManagerService
    {
        private readonly GridManagerMono mono;
        private readonly ObservableList<GridCell> selectedCells;
        private readonly SharedDataMono sharedData;
        private GridCell currentHoveredCell;

        public GridManagerService(
            GridManagerMono mono,
            SharedDataMono sharedData)
        {
            this.mono = mono;
            this.sharedData = sharedData;
            selectedCells = new ObservableList<GridCell>();
            selectedCells.CollectionChanged += delegate
            {
                mono.SelectedCellsChangedEvent.Invoke(selectedCells);
            };
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
                selectedCells.Remove(cell);
                cell.Unselect();
            }
            else if (cell.Status is CellStatus.MouseHover or CellStatus.Normal)
            {
                selectedCells.Add(cell);
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
            (bool isInGrid, GridPosition position) = worldPosition.ToGridPosition(sharedData.grid);

            if (!isInGrid)
            {
                return (false, null);
            }

            return (true, mono.Cells[position.X, position.Z]);
        }
    }
}