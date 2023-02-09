using System;
using System.Collections.Generic;
using System.Reflection;
using _src.Extensions;
using _src.Game.TurnCycle.TurnSteps;
using _src.Grid.GridManager;
using _src.Grid.Models;
using _src.Skill.UI.Button;
using _src.Towers.Stone;
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
        private List<TowerMono> placedTowers;

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
            placedTowers = new List<TowerMono>(5);
        }

        public override void OnEnter(object param = null)
        {
            placedTowers.Clear();
            MethodBase method = MethodBase.GetCurrentMethod();
            string className = method.DeclaringType.Name;
            Debug.Log($"{className}.{method.Name}");
        }

        public override void OnExit()
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            string className = method.DeclaringType.Name;
            Debug.Log($"{className}.{method.Name}");
        }

        private void OnButtonClick()
        {
            if (isPressed is false)
            {
                //skill.Disable();
                isPressed = true;
                cancelPlacing = towerPlacer.EnableTowerHower(OnTowerPlaceSuccess, OnTowerPlaceCancel);
            }
            else
            {
                //skill.Activate();
                isPressed = false;
            }
        }

        private void OnTowerPlaceCancel()
        {
            Debug.Log(
                "Tower.Place.Cancel\n"
              + $"Total Stone Count:{placedTowers.Count}");
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
              + $"Total Stone Count:{placedTowers}");
            
            Transform prefab = RandomTowerGenerator.NextRandomTowerPrefab();
            Vector3 worldPosition = position.ToWorldPosition(sharedData.grid.cellSize);
            Transform spawn = Object.Instantiate(prefab, worldPosition, Quaternion.identity);
            var tower = spawn.GetComponent<TowerMono>();
            tower.Cell = gridCell;
            gridCell.Tower = tower;
            gridCell.Hide();
            placedTowers.Add(tower);
            
            if (placedTowers.Count == 5)
            {
                cancelPlacing.Invoke();
                Exit(placedTowers);
            }
        }
    }
}