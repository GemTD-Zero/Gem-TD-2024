using _src.Grid.Visual;
using JetBrains.Annotations;
using UnityEngine;

namespace _src.Grid.GridManager
{
    [UsedImplicitly]
    public class GridManagerService
    {
        private readonly GridVisualManagerMono gridVisualManager;
        private readonly GridManagerMono mono;
        private readonly SharedDataMono sharedData;

        public GridManagerService(
            GridManagerMono mono,
            SharedDataMono sharedData,
            GridVisualManagerMono gridVisualManager)
        {
            this.mono = mono;
            this.sharedData = sharedData;
            this.gridVisualManager = gridVisualManager;
        }

        public void OnClicked(Vector3 mouseClickedWorlsPosition)
        {
            CellPosition position = mouseClickedWorlsPosition.ToGridPosition(sharedData.grid.cellSize);
            CellVisualMono visual = gridVisualManager.Visuals[position.X, position.Z];
            visual.ShowSelected(); 
        }
    }
}