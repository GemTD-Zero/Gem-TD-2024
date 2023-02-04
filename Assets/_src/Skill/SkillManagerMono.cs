using _src.Skill.Skills;
using _src.Skill.UI;
using UnityEngine;

namespace _src.Skill
{
    public class SkillManagerMono : MonoBehaviour
    {
        [SerializeField]
        private SkillButtonUI[] buttons;

        private void Start()
        {
            var stoneAddSkill = new StoneAddSkill();
            var stoneRemoveSkill = new StoneRemoveSkill();
            buttons[0].Initialize(stoneAddSkill);
            buttons[1].Initialize(stoneRemoveSkill);
        }
    }
}