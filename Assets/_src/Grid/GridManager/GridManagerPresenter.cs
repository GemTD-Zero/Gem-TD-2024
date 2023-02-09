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
            Vector3 mouseWorldPosition = mouseManagerMono.GetMouseWorldPosition();
            service.OnMouseOver(mouseWorldPosition);

            if (Input.GetMouseButtonDown(0))
            {
                service.OnClicked(mouseWorldPosition);
            }
        }
    }
}