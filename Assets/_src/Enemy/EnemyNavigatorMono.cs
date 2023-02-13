using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _src.Grid.GridManager;
using Unity.AI.Navigation;
using UnityEngine;

namespace _src.Enemy
{
    [RequireComponent(typeof(NavMeshSurface))]
    public class EnemyNavigatorMono : MonoBehaviour
    {

        [SerializeField]
        private Transform[] destinations;

        [SerializeField]
        private GridManagerMono gridManager;

        [SerializeField]
        private SharedDataMono sharedData;

        private NavMeshSurface surface;

        [SerializeField]
        private NavMeshPlayerMono player;

        private int targetIndex;

        private void Start()
        {
            surface = GetComponent<NavMeshSurface>();
            //player.transform.position = destinations[targetIndex++].position;
            //SetNextDestination();
        }

        private void SetNextDestination()
        {
            targetIndex %= destinations.Length;
            player.SetDestination(destinations[targetIndex++].position);
        }

        private void FixedUpdate()
        {
            if (player.IsAtDestionation())
            {
                SetNextDestination();
            }
        }
        

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Vector3[] positions = destinations.Select(o => o.transform.position).ToArray();
            Gizmos.DrawLineStrip(positions, false);
        }
    }
}