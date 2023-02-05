using System;
using _src.Grid.GridManager;
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
            data.gridManager.SpawnGrid(data.sharedData.grid);
            data.gridVisualManager.SpawnVisuals(data.sharedData.grid);
        }

        [Serializable]
        public class GameManagerData
        {
            public GridVisualManagerMono gridVisualManager;
            public GridManagerMono gridManager;
            public SharedDataMono sharedData;
        }
    }
}