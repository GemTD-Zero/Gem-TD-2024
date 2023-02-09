using JetBrains.Annotations;
using UnityEngine;

namespace _src.Towers.TowerSelection
{
    [UsedImplicitly]
    public class TowerSelectionPresenter
    {
        private readonly TowerSelectionMono mono;
        private readonly TowerSelectionService service;

        public TowerSelectionPresenter(
            TowerSelectionMono mono,
            TowerSelectionService service)
        {
            this.mono = mono;
            this.service = service;
            Debug.Log(nameof(TowerSelectionPresenter));
        }

    }
}