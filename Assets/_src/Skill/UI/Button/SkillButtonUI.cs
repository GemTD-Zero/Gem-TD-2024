using System;
using _src.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _src.Skill.UI.Button
{
    public class SkillButtonUI : MonoBehaviour
    {
        [SerializeField]
        private UiControlsData ui;

        private float coolDown;
        private CooldownWaiter waiter;

        private void SetCooldown(float cooldownInMilliseconds)
        {
            coolDown = cooldownInMilliseconds;
        }

        public void SetSkillImage(Texture2D texture)
        {
            var rectangle = new Rect(0.0f, 0.0f, texture.width, texture.height);
            var pivot = new Vector2(0.5f, 0.5f);
            const float pixelsPerUnit = 100.0f;
            var sprite = Sprite.Create(texture, rectangle, pivot, pixelsPerUnit);
            ui.skillImage.sprite = sprite;
        }

        public void AddButtonListener(UnityAction onButtonClick)
        {
            ui.button.onClick.AddListener(onButtonClick);
        }

        public void Activate()
        {
            ui.button.interactable = true;
            ui.cooldownText.SetDisabled();
            ui.cooldownImage.SetDisabled();
        }

        public void Disable()
        {
            ui.button.interactable = false;
            ui.cooldownText.SetDisabled();
            ui.cooldownImage.SetActivated();
        }

        [Serializable]
        public class UiControlsData
        {
            public Image cooldownImage;
            public TextMeshProUGUI cooldownText;
            public UnityEngine.UI.Button button;
            public Image skillImage;
        }
    }
}