using System;
using System.Collections.Generic;
using _src.Grid.Models;
using UnityEngine;

namespace _src.Grid.GridManager
{
    public class GridManagerMono : MonoBehaviour
    {
        [SerializeField]
        private Data debugData;

        [SerializeField]
        private Transform gridVisualPrefab;

        [SerializeField]
        private Transform gridParent;
        
        public GridCell[,] Cells { get; private set; }
        
        public Action<IReadOnlyCollection<GridCell>> SelectedCellsChangedEvent { get; set; }

        private void OnValidate()
        {
            if (debugData.debugObjectsParent == null)
            {
                return;
            }

            debugData.debugObjectsParent.gameObject.SetActive(debugData.showDebugObjects);
        }
        

        public void HideAllVisuals()
        {
            foreach (GridCell cell in Cells)
            {
                cell.Hide();
            }
        }
        
        public void SpawnGrid(GridData data)
        {
            var generator = new GridGenerator(data, gridVisualPrefab, gridParent);
            Cells = generator.CreateCells();
            generator.SpawnDebugObjects(debugData.debugPrefab, debugData.debugObjectsParent);
        }

        [Serializable]
        public class Data
        {
            public Transform debugPrefab;
            public Transform debugObjectsParent;
            public bool showDebugObjects;
        }
    }
}