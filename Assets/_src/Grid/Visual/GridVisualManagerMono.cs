using System;
using _src.Grid.Models;
using UnityEngine;

namespace _src.Grid.Visual
{
    public class GridVisualManagerMono : MonoBehaviour
    {
        [SerializeField]
        private VisualData visualData;

        public CellVisualMono[,] Visuals { get; private set; }

        public void SpawnVisuals(GridData gridData)
        {
            if (Visuals != null)
            {
                throw new NotImplementedException($"{nameof(SpawnVisuals)} is called twice");
            }

            Visuals = new CellVisualMono[gridData.width, gridData.height];

            for (var x = 0; x < gridData.width; x++)
            {
                for (var z = 0; z < gridData.height; z++)
                {
                    CellVisualMono visual = SpawnVisual(x, z, gridData.cellSize, visualData.visualPrefab);
                    Visuals[x, z] = visual;
                }
            }
        }

        private CellVisualMono SpawnVisual(int x, int z, float cellSize, Transform prefab)
        {
            var cellPosition = new CellPosition(x, z);
            Vector3 worldPosition = cellPosition.ToWorldPosition(cellSize);
            Transform visual = Instantiate(prefab, worldPosition, Quaternion.identity);
            visual.SetParent(visualData.visualsParent, false);
            return visual.GetComponent<CellVisualMono>();
        }

        [Serializable]
        public class VisualData
        {
            public Transform visualPrefab;
            public Transform visualsParent;
        }
    }
}