using UnityEngine;

namespace _src.Skill.Skills
{
    public class StoneRemoveSkill : SkillBase
    {
        public StoneRemoveSkill() : base(Resources.Load<Texture2D>("Skills/Skill.Stone.Remove"), 1f) { }

        public override void Activate()
        {
            Debug.Log("Skill.Stone.Remove");
        }
    }
}