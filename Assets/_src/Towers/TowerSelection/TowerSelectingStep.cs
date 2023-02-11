using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using _src.Extensions;
using _src.Game.TurnCycle.TurnSteps;
using _src.Grid.GridManager;
using _src.Grid.Models;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _src.Towers.TowerSelection
{
    public class TowerSelectingStep : BaseStep
    {
        private readonly GridManagerMono gridManager;
        private readonly SharedDataMono sharedData;
        private readonly Transform stonePrefab;
        private List<GridCell> gridCells;

        public TowerSelectingStep(
            GridManagerMono gridManager,
            Transform stonePrefab,
            SharedDataMono sharedData)
        {
            this.gridManager = gridManager;
            this.stonePrefab = stonePrefab;
            this.sharedData = sharedData;
        }

        public override void OnEnter(object param)
        {
            if (param is List<GridCell> { Count: 5 } items)
            {
                gridCells = items;
                gridManager.SelectedCellsChangedEvent += SelectedCellsChangedEvent;
            }
            else
            {
                Debug.LogError($"Something went wrong:{param}");
            }


            gridManager.HideAllVisuals();

            foreach (GridCell cell in gridCells)
            {
                cell.Unselect();
            }
        }

        public override void OnExit()
        {
        }

        private void SelectedCellsChangedEvent(IReadOnlyCollection<GridCell> cells)
        {
            if (cells.Count != 1)
            {
                throw new Exception($"Selected Cells Count is Wrong is {cells.Count}");
            }

            GridCell selectedCell = cells.First();
            foreach (GridCell cell in gridCells)
            {
                cell.Hide();

                if (cell != selectedCell)
                {
                    Transform stoneObject = Object.Instantiate(
                        stonePrefab,
                        cell.Position.ToWorldPosition(sharedData.grid.cellSize),
                        Quaternion.identity);
                    cell.Tower.ChangeTower(stoneObject);
                }
            }

            //selectedCell.Tower.ChangeTower(stonePrefab);
        }
    }
}