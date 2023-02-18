using _src.Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace _src.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAgentMono : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Vector3[] destinations;
        private int destionationIndex;

        public void SetDestinations(Vector3[] enemyDestionations)
        {
            destinations = enemyDestionations;
            transform.position = enemyDestionations[0];
            SetNextDestionation();
        }

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!agent.IsAtDestination())
            {
                return;
            }
            
            SetNextDestionation();
        }

        private void OnDrawGizmosSelected()
        {
            if (!agent.hasPath)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawLineList(agent.path.corners);
        }

        private void SetNextDestionation()
        {
            if (destionationIndex >= destinations.Length)
            {
                return;
            }
            
            agent.SetDestination(destinations[destionationIndex++]);
        }
    }
}