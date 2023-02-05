using System;
using UnityEngine;

namespace _src.Skill.Skills
{
    public class PlaceTowerSkill : SkillBase
    {
        private readonly Action onActivate;
        private bool isActivated;

        public PlaceTowerSkill(Action onActivate) : base(Resources.Load<Texture2D>("Skills/Skill.Stone.Add"), 1f)
        {
            this.onActivate = onActivate;
        }


        public override void Activate()
        {
            isActivated = true;
            onActivate.Invoke();
            Debug.Log("Skill.Tower.Place");
        }
        
    }
}