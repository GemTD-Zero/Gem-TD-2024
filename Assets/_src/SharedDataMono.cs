using System;
using _src.Grid.Models;
using UnityEngine;

namespace _src
{
    public class SharedDataMono : MonoBehaviour
    {
        public GridData grid;
        public Transform[] enemyDestionations;
        public EnemyPrefabs enemyPrefabs;

        [Serializable]
        public struct EnemyPrefabs
        {
            public Transform wave1;
        }
    }
}