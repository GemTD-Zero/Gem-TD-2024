using System;
using _src.Grid;
using _src.Player;
using _src.Towers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _src.Skill.Skills
{
    public class PlaceTowerSkillMono : MonoBehaviour
    {
        private const int TowerCount = 5;

        [SerializeField]
        public SkillUiData ui;

        [SerializeField]
        private MouseManagerMono mouseManager;

        [SerializeField]
        private GridManagerMono gridManager;

        [SerializeField]
        private Transform towerPrefab;

        [SerializeField]
        private SharedDataMono sharedData;

        private bool isButtonClicked;
        private int leftTowerCount;
        private Transform mouseFollowObject;
        private CooldownWaiter waiter;

        private void Start()
        {
            EnableButton();
            ui.button.onClick.AddListener(OnButtonClick);
            mouseFollowObject = Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);
            mouseFollowObject.SetParent(transform, false);
            mouseFollowObject.gameObject.SetActive(false);
            leftTowerCount = TowerCount;
        }

        private void Update()
        {
            if (!isButtonClicked)
            {
                return;
            }

            if (leftTowerCount <= 0)
            {
                mouseFollowObject.gameObject.SetActive(false);
                return;
            }

            //TODO check if cell has already tower
            //TODO or only show visual for possible locations and raycast to those locations

            Vector3 worldPosition = mouseManager.GetMouseWorldPosition();
            CellPosition cellPosition = worldPosition.ToGridPosition(sharedData.grid.cellSize);
            mouseFollowObject.transform.position = cellPosition.ToWorldPosition(sharedData.grid.cellSize);

            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            if (IsMouseOverUI())
            {
                return;
            }

            Transform tower = RandomTowerGenerator.RandomTower();
            Instantiate(tower, cellPosition.ToWorldPosition(sharedData.grid.cellSize), Quaternion.identity);
            EnableButton();
            mouseFollowObject.gameObject.SetActive(false);
            isButtonClicked = false;
            leftTowerCount--;
            Debug.Log(leftTowerCount);
        }

        private static bool IsMouseOverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        private void OnButtonClick()
        {
            isButtonClicked = true;
            mouseFollowObject.gameObject.SetActive(true);
            DisableButton();
        }

        private void EnableButton()
        {
            ui.cooldownText.gameObject.SetActive(false);
            ui.cooldownImage.gameObject.SetActive(false);
            ui.button.interactable = true;
        }

        private void DisableButton()
        {
            ui.button.interactable = false;
        }

        [Serializable]
        public class SkillUiData
        {
            public Button button;
            public Image cooldownImage;
            public TextMeshProUGUI cooldownText;
            public Image skillImage;
        }
    }
}