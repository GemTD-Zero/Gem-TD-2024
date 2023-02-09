using System.Collections.Generic;
using System.Reflection;
using _src.Game.TurnCycle.TurnSteps;
using _src.Grid.GridManager;
using _src.Grid.Models;
using _src.Towers.Stone;
using UnityEngine;

namespace _src.Towers.TowerSelection
{
    public class TowerSelectingStep : BaseStep
    {
        private readonly GridManagerMono gridManager;
        private readonly SharedDataMono sharedData;
        private readonly TowerSelectionMono towerSelection;
        private List<TowerMono> towers;

        public TowerSelectingStep(
            GridManagerMono gridManager,
            SharedDataMono sharedData,
            TowerSelectionMono towerSelection)
        {
            this.gridManager = gridManager;
            this.sharedData = sharedData;
            this.towerSelection = towerSelection;
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

        public override void OnExit()
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            string className = method.DeclaringType.Name;
            Debug.Log($"{className}.{method.Name}");
        }

        private void SelectedCellsChangedEvent(IReadOnlyCollection<GridCell> obj)
        {
            Debug.Log($"Collection Changed:{obj.Count}");
        }
    }
}