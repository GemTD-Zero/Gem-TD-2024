using JetBrains.Annotations;
using UnityEngine;

namespace _src.Towers.TowerSelection
{
    [UsedImplicitly]
    public class TowerSelectionService
    {
        private readonly TowerSelectionMono mono;
        private bool isActive;

        public TowerSelectionService(TowerSelectionMono mono)
        {
            this.mono = mono;
            this.mono.Activate += OnActivate;
            Debug.Log("Tower Selection Service");
        }

        private void OnActivate(TowerSelectingStep step)
        {
            isActive = true;
        }
    }
}