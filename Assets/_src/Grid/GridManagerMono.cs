using System;
using UnityEngine;

namespace _src.Grid
{
    public class GridManagerMono : MonoBehaviour
    {
        [SerializeField]
        private Data data;

        public GridCell[,] Cells { get; private set; }

        private void Start()
        {
            var generator = new GridGenerator(data.width, data.height, data.cellSize);
            Cells = generator.CreateCells();
            generator.SpawnDebugObjects(data.debugPrefab, data.debugObjectsParent);
        }

        private void OnValidate()
        {
            if (data.debugObjectsParent == null)
            {
                return;
            }

            data.debugObjectsParent.gameObject.SetActive(data.showDebugObjects);
        }

        [Serializable]
        public class Data
        {
            public Transform debugPrefab;
            public Transform debugObjectsParent;
            public bool showDebugObjects;

            [Header("Values")]
            public int width;
            public int height;
            public float cellSize;
        }
    }
}