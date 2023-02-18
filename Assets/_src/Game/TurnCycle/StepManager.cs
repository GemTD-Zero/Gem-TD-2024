using _src.Enemy;
using _src.Game.TurnCycle.TurnSteps;
using _src.Grid.GridManager;
using _src.Skill;
using _src.Towers.TowerPlacement;
using _src.Towers.TowerSelection;
using UnityEngine;

namespace _src.Game.TurnCycle
{
    public class StepManagerMono : MonoBehaviour
    {
        public TowerPlacerMono towerPlacer;
        public TowerSelectionMono towerSelection;
        public SkillBarManagerMono skillBarManager;
        public GridManagerMono gridManager;
        public SharedDataMono sharedData;
        public Transform stonePrefab;
        public EnemySpawnerMono enemySpawner;

        private BaseStep currentNode;

        private void Awake()
        {
            var stonePlacing = new TowerPlacerStep(
                towerPlacer,
                skillBarManager.skillBar.firstSkill,
                gridManager,
                sharedData);
            var stoneSelectingStep = new TowerSelectingStep(gridManager, stonePrefab, sharedData);
            var spawnStep = new SpawnStep(sharedData, enemySpawner);

            stonePlacing.SetNext(stoneSelectingStep);
            stoneSelectingStep.SetNext(spawnStep);
            spawnStep.SetNext(stonePlacing);

            currentNode = stonePlacing;
            currentNode.OnEnter();
        }
    }
}