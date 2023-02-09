using System;
using _src.Skill.UI.Button;
using UnityEngine;

namespace _src.Skill
{
    public class SkillBarManagerMono : MonoBehaviour
    {
        public SkillBar skillBar;

        [Serializable]
        public struct SkillBar
        {
            public SkillButtonUI firstSkill;
            public SkillButtonUI secondSkill;
            public SkillButtonUI thirdSkill;
            public SkillButtonUI fourthSkill;
            public SkillButtonUI fifthSkill;
        }
    }
}