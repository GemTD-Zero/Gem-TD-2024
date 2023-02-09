using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using _src.Game.TurnCycle.TurnSteps;
using _src.Grid.GridManager;
using _src.Grid.Models;
using _src.Towers.Stone;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _src.Towers.TowerSelection
{
    public class TowerSelectingStep : BaseStep
    {
        private readonly GridManagerMono gridManager;
        private readonly Transform stonePrefab;
        private List<TowerMono> towers;

        public TowerSelectingStep(GridManagerMono gridManager, Transform stonePrefab)
        {
            this.gridManager = gridManager;
            this.stonePrefab = stonePrefab;
        }

        public override void OnEnter(object param)
        {
            if (param is List<TowerMono> { Count: 5 } items)
            {
                towers = items;
                gridManager.SelectedCellsChangedEvent += SelectedCellsChangedEvent;
            }
            else
            {
                Debug.LogError($"Something went wrong:{param}");
            }

            MethodBase method = MethodBase.GetCurrentMethod();
            string className = method.DeclaringType.Name;
            Debug.Log($"{className}.{method.Name}");

            gridManager.HideAllVisuals();

            foreach (TowerMono tower in towers)
            {
                tower.Cell.Unselect();
            }
        }
\
        public override void OnExit()
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            string className = method.DeclaringType.Name;
            Debug.Log($"{className}.{method.Name}");
        }

        private void SelectedCellsChangedEvent(IReadOnlyCollection<GridCell> cells)
        {
            if (cells.Count != 1)
            {
                throw new Exception($"Selected Cells Count is Wrong is {cells.Count}");
            }

            GridCell selectedCell = cells.First();
            
        }
    }
}