using UnityEngine;

namespace _src.Towers
{
    public static class TowerGenerator
    {
        public static Transform NextRandomTowerPrefab()
        {
            return Resources.Load<Transform>("Towers/Sample Tower Prefab");
        }

        public static Transform GetStonePrefab()
        {
            return Resources.Load<Transform>("Towers/Stone/Stone Prefab");
        }
    }
}