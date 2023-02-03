using _src.Skill;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _src.UI
{
    public class SkillButtonUI : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private Image cooldownImage;

        [SerializeField]
        private TextMeshProUGUI cooldownText;

        private readonly float coolDownTime = 5f;
        private bool isOnCooldown;
        private CooldownWaiter waiter;

        private void Start()
        {
            cooldownText.text = string.Empty;
            button.onClick.AddListener(OnButtonClick);
        }

        private void Update()
        {
            if (!isOnCooldown)
            {
                return;
            }

            float leftTime = waiter.Update();

            UpdateUi(leftTime);
        }

        private void UpdateUi(float leftTime)
        {
            float percentage = 1 - leftTime / coolDownTime;
            var text = ((int)leftTime + 1).ToString();
            cooldownImage.fillAmount = percentage;
            cooldownText.text = text;
        }

        private void OnButtonClick()
        {
            StartCooldown();
        }

        private void StartCooldown()
        {
            waiter = new CooldownWaiter(coolDownTime, EndCooldown);
            PutToCooldown();
        }

        private void EndCooldown()
        {
            button.interactable = true;
            cooldownImage.enabled = false;
            cooldownText.enabled = false;
            isOnCooldown = false;
        }

        private void PutToCooldown()
        {
            button.interactable = false;
            cooldownImage.enabled = true;
            cooldownText.enabled = true;
            isOnCooldown = true;
        }
    }
}