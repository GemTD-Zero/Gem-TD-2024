using System;
using _src.Skill.Skills;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _src.Skill.UI
{
    public class SkillButtonUI : MonoBehaviour
    {
        [SerializeField]
        private SkillData data;

        private bool isOnCooldown;
        private SkillBase skill;
        private CooldownWaiter waiter;

        private void Start()
        {
            data.cooldownText.text = string.Empty;
            data.button.onClick.AddListener(OnButtonClick);
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

        public void Initialize(SkillBase o)
        {
            skill = o;
            data.skillImage.gameObject.SetActive(true);
            data.skillImage.sprite = o.SkillSprite;
            data.cooldownImage.gameObject.SetActive(false);
        }

        private void UpdateUi(float leftTime)
        {
            float percentage = 1 - leftTime / skill.Cooldown;
            var text = ((int)leftTime + 1).ToString();
            data.cooldownImage.fillAmount = percentage;
            data.cooldownText.text = text;
        }

        private void OnButtonClick()
        {
            skill.Activate();
            StartCooldown();
        }

        private void StartCooldown()
        {
            waiter = new CooldownWaiter(skill.Cooldown, EndCooldown);
            PutToCooldown();
        }

        private void EndCooldown()
        {
            data.button.interactable = true;
            data.cooldownImage.gameObject.SetActive(false);
            data.cooldownText.gameObject.SetActive(false);
            isOnCooldown = false;
        }

        private void PutToCooldown()
        {
            data.button.interactable = false;
            data.cooldownImage.gameObject.SetActive(true);
            data.cooldownText.gameObject.SetActive(true);
            isOnCooldown = true;
        }

        [Serializable]
        public class SkillData
        {
            public Button button;
            public Image cooldownImage;
            public TextMeshProUGUI cooldownText;
            public Image skillImage;
        }
    }
}