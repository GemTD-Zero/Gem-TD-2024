using _src.Extensions;
using _src.Player;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace _src.Grid.GridManager
{
    [UsedImplicitly]
    public class GridManagerPresenter : ITickable
    {
        private readonly MouseManagerMono mouseManagerMono;
        private readonly GridManagerService service;

        public GridManagerPresenter(
            MouseManagerMono mouseManagerMono,
            GridManagerService service)
        {
            this.mouseManagerMono = mouseManagerMono;
            this.service = service;
        }

        public void Tick()
        {
            // if (Helpers.IsMouseOverUI())
            // {
            //     return;
            // }
            //
            // Vector3 mousePosition = mouseManagerMono.GetMouseWorldPosition();
            //
            // if (Input.GetMouseButtonDown(0))
            // {
            //     service.OnClicked(mousePosition);
            // }
            // else
            // {
            //     service.OnMouseOver(mousePosition);
            // }
        }
    }
}