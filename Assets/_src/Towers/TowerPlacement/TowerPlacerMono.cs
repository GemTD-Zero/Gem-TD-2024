using System;
using _src.Extensions;
using _src.Grid;
using _src.Grid.Models;
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

        private GridPosition currentPosition;
        private Transform howerObject;

        private bool shouldHowerOver;
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

            (bool isIngrid, GridPosition position) = MouseHowerer.MoveObjectToMousePosition(mouseManager, sharedData, howerObject);
            if (isIngrid)
            {
                currentPosition = position;
            }


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