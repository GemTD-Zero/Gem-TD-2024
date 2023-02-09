using System;
using _src.Extensions;
using _src.Grid;
using _src.Player;
using UnityEngine;

namespace _src.Towers.TowerPlacement
{
    public class TowerPlacerMono : MonoBehaviour
    {
        [SerializeField]
        private Transform towerPlacementHowerPrefab;

        [SerializeField]
        private MouseManagerMono mouseManager;

        [SerializeField]
        private SharedDataMono sharedData;

        private bool shouldHowerOver;
        private Transform howerObject;
        private GridPosition currentPosition;
        private Action towerPlaceCancel;
        private Action<GridPosition> towerPlaceSuccess;

        private void Start()
        {
            howerObject = Instantiate(towerPlacementHowerPrefab, Vector3.zero, Quaternion.identity);
            howerObject.SetDeactivated();
        }

        private void Update()
        {
            if (!shouldHowerOver)
            {
                return;
            }

            MoveObjectToMouseGridPosition();

            if (Input.GetMouseButtonDown(0))
            {
                if (howerObject.IsActivated())
                {
                    towerPlaceSuccess.Invoke(currentPosition);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                towerPlaceCancel.Invoke();
            }
        }

        private void MoveObjectToMouseGridPosition()
        {
            Vector3 worldPosition = mouseManager.GetMouseWorldPosition();
            (bool isInGrid, GridPosition gridPosition) = worldPosition.ToGridPosition(sharedData.grid);

            if (!isInGrid)
            {
                howerObject.SetDeactivated();
                return;
            }

            currentPosition = gridPosition;
            howerObject.SetActivated();
            howerObject.transform.position = gridPosition.ToWorldPosition(sharedData.grid.cellSize);
        }

        public Action EnableTowerHower(Action<GridPosition> onTowerPlaceSuccess, Action onTowerPlaceCancel)
        {
            shouldHowerOver = true;
            towerPlaceSuccess = onTowerPlaceSuccess;
            towerPlaceCancel = onTowerPlaceCancel;
            howerObject.SetActivated();
            return StopPlacing;
        }

        private void StopPlacing()
        {
            shouldHowerOver = false;
        }
    }
}