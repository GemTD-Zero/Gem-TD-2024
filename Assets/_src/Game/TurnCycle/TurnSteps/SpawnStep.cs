using _src.Enemy;

namespace _src.Game.TurnCycle.TurnSteps
{
    public class SpawnStep : BaseStep
    {
        private readonly EnemySpawnerMono enemySpawner;

        //TODO check if all enemies are alive
        //TODO Exit when all enemies are dead
        private readonly SharedDataMono sharedData;

        private readonly int spawnCount = 10;

        public SpawnStep(
            SharedDataMono sharedData,
            EnemySpawnerMono enemySpawner)
        {
            this.sharedData = sharedData;
            this.enemySpawner = enemySpawner;
        }

        public override void OnEnter(object param = null)
        {
            enemySpawner.SpawnEnemies(sharedData.enemyPrefabs.wave1, spawnCount);
        }

        public override void OnExit() { }
    }
}