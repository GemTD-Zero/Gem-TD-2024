using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _src.Enemy
{
    public class EnemySpawnerMono : MonoBehaviour
    {
        [SerializeField]
        private SharedDataMono sharedData;

        private readonly float spawnInterval = 0.1f;

        private List<EnemyAgentMono> agents;
        private Vector3[] destinations;

        private void Start()
        {
            destinations = new Vector3[sharedData.enemyDestionations.Length];
            for (var i = 0; i < sharedData.enemyDestionations.Length; i++)
            {
                Vector3 destination = sharedData.enemyDestionations[i].position;
                destinations[i] = destination;
            }

            agents = new List<EnemyAgentMono>();
        }

        public void SpawnEnemies(Transform prefab, int count)
        {
            if (prefab == null)
            {
                Debug.LogError("prefab is null #1");
            }
            
            StartCoroutine(SpawnEnemiesRoutine(prefab, count));
        }

        private IEnumerator SpawnEnemiesRoutine(Transform prefab, int count)
        {
            if (prefab == null)
            {
                Debug.LogError("prefab is null #3");
            }

            while (true)
            {
                for (var i = 0; i < count; i++)
                {
                    EnemyAgentMono enemy = SpawnEnemyAndSetDestionation(prefab);
                    agents.Add(enemy);
                    yield return new WaitForSeconds(spawnInterval);
                }
                yield break;
            }
        }

        private EnemyAgentMono SpawnEnemyAndSetDestionation(Transform prefab)
        {
            if (prefab == null)
            {
                Debug.LogError("prefab is null #4");
            }
            
            Transform enemyObject = Instantiate(prefab, transform);
            var enemy = enemyObject.gameObject.GetComponent<EnemyAgentMono>();
            enemy.SetDestinations(destinations);
            return enemy;
        }
    }
}