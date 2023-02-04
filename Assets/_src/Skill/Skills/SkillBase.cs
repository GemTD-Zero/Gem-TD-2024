using UnityEngine;

namespace _src.Skill.Skills
{
    public abstract class SkillBase
    {
        protected SkillBase(Texture2D texture, float cooldown)
        {
            var rectangle = new Rect(0.0f, 0.0f, texture.width, texture.height);
            var pivot = new Vector2(0.5f, 0.5f);
            const float pixelsPerUnit = 100.0f;
            var sprite = Sprite.Create(texture, rectangle, pivot, pixelsPerUnit);
            SkillSprite = sprite;
            Cooldown = cooldown;
        }

        public virtual float Cooldown { get; }
        public virtual Sprite SkillSprite { get; }
        public abstract void Activate();
    }
}