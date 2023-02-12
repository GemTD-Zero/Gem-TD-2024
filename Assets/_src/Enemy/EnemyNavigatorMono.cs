using Unity.AI.Navigation;
using UnityEngine;

namespace _src.Enemy
{
    [RequireComponent(typeof(NavMeshSurface))]
    public class EnemyNavigatorMono : MonoBehaviour
    {
        [SerializeField]
        private NavMeshSurface surface;

        private void Start()
        {
            surface = GetComponent<NavMeshSurface>();
        }
    }
}