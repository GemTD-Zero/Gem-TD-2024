using System;
using _src.Grid.Models;
using UnityEngine;

namespace _src.Grid.Visual
{
    public class GridVisualManagerMono : MonoBehaviour
    {
        [SerializeField]
        private VisualData visualData;

        private CellVisualMono[,] visuals;


        public void SpawnVisuals(GridData gridData)
        {
            if (visuals != null)
            {
                throw new NotImplementedException($"{nameof(SpawnVisuals)} is called twice");
            }

            visuals = new CellVisualMono[gridData.width, gridData.height];

            for (var x = 0; x < gridData.width; x++)
            {
                for (var z = 0; z < gridData.height; z++)
                {
                    SpawnVisual(x, z, gridData.cellSize);
                }
            }
        }

        private void SpawnVisual(int x, int z, float cellSize)
        {
            var cellPosition = new CellPosition(x, z);
            Vector3 worldPosition = cellPosition.ToWorldPosition(cellSize);
            Transform visual = Instantiate(visualData.visualPrefab, worldPosition, Quaternion.identity);
            visual.SetParent(visualData.visualsParent, false);
        }

        [Serializable]
        public class VisualData
        {
            public Transform visualPrefab;
            public Transform visualsParent;
        }
    }
}