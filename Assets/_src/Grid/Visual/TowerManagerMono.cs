using System;
using UnityEngine;

namespace _src.Grid.Visual
{
    public class GridVisualManagerMono : MonoBehaviour
    {
        [SerializeField]
        private Data data;

        private CellVisualMono[,] visuals;

        private void Start()
        {
            SpawnVisuals(10, 10, 2);
        }

        public void SpawnVisuals(int width, int height, float cellSize)
        {
            if (visuals != null)
            {
                throw new NotImplementedException($"{nameof(SpawnVisuals)} is called twice");
            }

            visuals = new CellVisualMono[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var z = 0; z < height; z++)
                {
                    SpawnVisual(x, z, cellSize);
                }
            }
        }

        private void SpawnVisual(int x, int z, float cellSize)
        {
            var cellPosition = new CellPosition(x, z);
            Vector3 worldPosition = cellPosition.ToWorldPosition(cellSize);
            Transform visual = Instantiate(data.visualPrefab, worldPosition, Quaternion.identity);
            visual.SetParent(data.visualsParent, false);
        }


        [Serializable]
        public class Data
        {
            public Transform visualPrefab;
            public Transform visualsParent;
        }
    }
}