using _src.Grid;
using _src.Player;
using _src.Skill.UI.Button;
using _src.Towers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _src.Skill.Skills
{
    // public class PlaceTowerSkill
    // {
    //     private readonly SkillButtonUI skillUi;
    //     private const int TowerCount = 5;
    //
    //     private MouseManagerMono mouseManager;
    //     private GridManagerMono gridManager;
    //     private Transform towerPrefab;
    //     private SharedDataMono sharedData;
    //
    //     private bool isButtonClicked;
    //     private int leftTowerCount;
    //     private Transform mouseFollowObject;
    //     
    //     
    //     public PlaceTowerSkill(SkillButtonUI skillUi)
    //     {
    //         this.skillUi = skillUi;
    //         skillUi.AddButtonListener(OnButtonClick);
    //     }
    //
    //     private void OnButtonClick()
    //     {
    //         isButtonClicked = true;
    //         skillUi.Disable();
    //     }
    //
    //     private void Start()
    //     {
    //         EnableButton();
    //         ui.button.onClick.AddListener(OnButtonClick);
    //         mouseFollowObject = Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);
    //         mouseFollowObject.SetParent(transform, false);
    //         mouseFollowObject.gameObject.SetActive(false);
    //         leftTowerCount = TowerCount;
    //     }
    //
    //     private void Update()
    //     {
    //         if (!isButtonClicked)
    //         {
    //             return;
    //         }
    //
    //         if (leftTowerCount <= 0)
    //         {
    //             mouseFollowObject.gameObject.SetActive(false);
    //             return;
    //         }
    //
    //         //TODO check if cell has already tower
    //         //TODO or only show visual for possible locations and raycast to those locations
    //
    //         Vector3 worldPosition = mouseManager.GetMouseWorldPosition();
    //         CellPosition cellPosition = worldPosition.ToGridPosition(sharedData.grid.cellSize);
    //         mouseFollowObject.transform.position = cellPosition.ToWorldPosition(sharedData.grid.cellSize);
    //
    //         if (!Input.GetMouseButtonDown(0))
    //         {
    //             return;
    //         }
    //
    //         if (IsMouseOverUI())
    //         {
    //             return;
    //         }
    //
    //         Transform tower = RandomTowerGenerator.RandomTower();
    //         Instantiate(tower, cellPosition.ToWorldPosition(sharedData.grid.cellSize), Quaternion.identity);
    //         EnableButton();
    //         mouseFollowObject.gameObject.SetActive(false);
    //         isButtonClicked = false;
    //         leftTowerCount--;
    //         Debug.Log(leftTowerCount);
    //     }
    //
    //     private static bool IsMouseOverUI()
    //     {
    //         return EventSystem.current.IsPointerOverGameObject();
    //     }
    //
    //     // private void OnButtonClick()
    //     // {
    //     //     isButtonClicked = true;
    //     //     mouseFollowObject.gameObject.SetActive(true);
    //     //     DisableButton();
    //     // }
    //     //
    //     // private void EnableButton()
    //     // {
    //     //     ui.cooldownText.gameObject.SetActive(false);
    //     //     ui.cooldownImage.gameObject.SetActive(false);
    //     //     ui.button.interactable = true;
    //     // }
    //     //
    //     // private void DisableButton()
    //     // {
    //     //     ui.button.interactable = false;
    //     // }
    //
    //     // [Serializable]
    //     // public class SkillUiData
    //     // {
    //     //     public Button button;
    //     //     public Image cooldownImage;
    //     //     public TextMeshProUGUI cooldownText;
    //     //     public Image skillImage;
    //     // }
    // }
}