using UnityEngine;

namespace _src.Skill.Skills
{
    public class StoneAddSkill : SkillBase
    {
        public StoneAddSkill() : base(Resources.Load<Texture2D>("Skills/Skill.Stone.Add"), 1f) { }

        public override void Activate()
        {
            Debug.Log("Skill.Stone.Add");
        }
    }
}