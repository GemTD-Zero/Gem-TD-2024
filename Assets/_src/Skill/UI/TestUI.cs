using UnityEngine;
using UnityEngine.UI;

namespace _src.Skill.UI
{
    public class TestUI : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private SkillButtonUI skillUI;

        private readonly float cd = 10f;

        private float angle;
        private CooldownWaiter waiter;

        private void Start()
        {
            //button.onClick.AddListener(OnButtonClick);
        }

        private void Update()
        {
            // if (waiter != null)
            // {
            //     float leftTime = waiter.Update();
            //     float percentage = 1 - leftTime / cd;
            //     skillUI.SetCooldown(percentage, ((int)leftTime + 1).ToString());
            // }
        }

        // private void OnButtonClick()
        // {
        //     waiter = new CooldownWaiter(cd, OnFinish);
        // }
        //
        // private void OnFinish()
        // {
        //     Debug.Log("Finished");
        //     skillUI.SetCooldown(0, string.Empty);
        //     waiter = null;
        // }
    }
}