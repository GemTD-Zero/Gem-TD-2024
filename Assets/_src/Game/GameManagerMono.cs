using System;
using _src.Grid;
using _src.Grid.Models;
using _src.Grid.Visual;
using UnityEngine;

namespace _src.Game
{
    public class GameManagerMono : MonoBehaviour
    {
        [SerializeField]
        private GameManagerData data;

        private void Start()
        {
            data.gridManager.SpawnGrid(data.gridData);
            data.gridVisualManager.SpawnVisuals(data.gridData);
        }

        [Serializable]
        public class GameManagerData
        {
            public GridVisualManagerMono gridVisualManager;
            public GridManagerMono gridManager;
            public GridData gridData;
        }
    }
}