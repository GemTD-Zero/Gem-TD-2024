using System;
using System.Collections.Generic;
using _src.Extensions;
using _src.Game.TurnCycle.TurnSteps;
using _src.Grid.GridManager;
using _src.Grid.Models;
using _src.Skill.UI.Button;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _src.Towers.TowerPlacement
{
    public class TowerPlacerStep : BaseStep
    {
        private readonly TowerPlacerMono towerPlacer;
        private readonly SkillButtonUI skill;
        private readonly GridManagerMono gridManager;
        private readonly SharedDataMono sharedData;
        private bool isPressed;
        private Action cancelPlacing;
        private List<GridCell> towerPlacedGridCells;

        public TowerPlacerStep(
            TowerPlacerMono towerPlacer, 
            SkillButtonUI skill,
            GridManagerMono gridManager,
            SharedDataMono sharedData)
        {
            this.towerPlacer = towerPlacer;
            this.skill = skill;
            this.gridManager = gridManager;
            this.sharedData = sharedData;
            this.skill.SetSkillImage(ResourcesHelper.Skills.TowerPlacerImage);
            skill.Activate();
            skill.AddButtonListener(OnButtonClick);
            towerPlacedGridCells = new List<GridCell>(5);
        }

        public override void OnEnter(object param = null)
        {
            towerPlacedGridCells.Clear();
        }

        public override void OnExit()
        {
            Debug.Log("Step.Tower.Place.Exited");
        }

        private void OnButtonClick()
        {
            if (isPressed is false)
            {
                isPressed = true;
                cancelPlacing = towerPlacer.EnableTowerHower(OnTowerPlaceSuccess, OnTowerPlaceCancel);
            }
            else
            {
                isPressed = false;
            }
        }

        private void OnTowerPlaceCancel()
        {
            Debug.Log(
                "Tower.Place.Cancel\n"
              + $"Total Stone Count:{towerPlacedGridCells.Count}");
            //TODO cancel tower placing
        }

        private void OnTowerPlaceSuccess(GridPosition position)
        {
            //TODO check if cell has tower when howering, not placing it
            GridCell gridCell = gridManager.Cells[position.X, position.Z];
            if (gridCell.Tower != null)
            {
                return;
            }
            
            Debug.Log(
                "Tower.Place.Success\n"
              + $"Position:{position.ToString()}\n"
              + $"Total Stone Count:{towerPlacedGridCells}");
            
            Transform prefab = TowerGenerator.NextRandomTowerPrefab();
            Vector3 worldPosition = position.ToWorldPosition(sharedData.grid.cellSize);
            Transform spawn = Object.Instantiate(prefab, worldPosition, Quaternion.identity);
            var tower = spawn.GetComponent<TowerMono>();
            gridCell.Tower = tower;
            gridCell.Hide();
            towerPlacedGridCells.Add(gridCell);
            
            if (towerPlacedGridCells.Count == 5)
            {
                cancelPlacing.Invoke();
                Exit(towerPlacedGridCells);
            }
        }
    }
}