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
        private int destinationIndex;

        public void SetDestinations(Vector3[] enemyDestionations)
        {
            destinations = enemyDestionations;
            transform.position = enemyDestionations[0];
            SetNextDestionation();
        }

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.Log($"agent is null");
            }
        }

        private void Update()
        {
            if (!agent.IsAtDestination())
            {
                return;
            }
            
            SetNextDestionation();
        }

        private void SetNextDestionation()
        {
            if (destinationIndex >= destinations.Length)
            {
                return;
                
            }
            Debug.Log($"Destination Index:{destinationIndex}");
            Vector3 destination = destinations[destinationIndex++];
            if (agent == null)
            {
                Debug.Log($"agent is null. destionation:{destination}");
            }
            agent.SetDestination(destination);
        }
    }
}