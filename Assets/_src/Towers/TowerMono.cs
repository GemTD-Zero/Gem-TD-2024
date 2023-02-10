using UnityEngine;

namespace _src.Towers
{
    public class TowerMono : MonoBehaviour
    {
        private Transform tower;

        private void Start()
        {
            tower = transform.GetChild(0);
        }

        public void ChangeTower(Transform newTower)
        {
            Destroy(tower.gameObject);
            tower = newTower;
            tower.SetParent(transform);
        }
    }
}