using _src.Skill.Skills;
using _src.Skill.UI.Button;
using UnityEngine;

namespace _src.Skill
{
    public class SkillManagerMono : MonoBehaviour
    {
        [SerializeField]
        private CooldownSkillButtonUI[] buttons;

        private SkillBase[] skills;

        private void Start()
        {
            // var stoneAddSkill = new PlaceTowerSkill();
            // var stoneRemoveSkill = new StoneRemoveSkill();
            // skills = new SkillBase[5];
            // skills[0] = stoneAddSkill;
            // skills[1] = stoneRemoveSkill;
            //
            // buttons[0].Initialize(stoneAddSkill);
            // buttons[1].Initialize(stoneRemoveSkill);
        }
    }
}