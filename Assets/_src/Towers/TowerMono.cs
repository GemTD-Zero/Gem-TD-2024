using System.Collections.Generic;
using UnityEngine;

namespace _src.Towers
{
    public class TowerMono : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> enemies;

        private Transform tower;

        [SerializeField]
        private float attackRange  = 3f;

        private void Start()
        {
            tower = transform.GetChild(0);
        }

        private void Update()
        {
            (Transform closestEnemy, float distance) = FindClosestTarget();
            if (closestEnemy != null)
            {
                // Vector3 lookingVector = closestTarget.position - transform.position;
                // lookingVector.y = transform.position.y;

                if (attackRange > distance)
                {
                    transform.LookAt(closestEnemy);    
                }
            }
        }

        private (Transform enemy, float distance) FindClosestTarget()
        {
            var minimum = float.MaxValue;
            Transform closestEnemy = null;
            foreach (Transform enemy in enemies)
            {
                float distance = (tower.position - enemy.position).sqrMagnitude;
                if (distance < minimum)
                {
                    minimum = distance;
                    closestEnemy = enemy;
                }
            }

            return (closestEnemy, Mathf.Sqrt(minimum));
        }

        public void ChangeTower(Transform newTower)
        {
            Destroy(tower.gameObject);
            tower = newTower;
            tower.SetParent(transform);
        }
    }
}