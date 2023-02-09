using UnityEngine;

namespace _src
{
    public static class ResourcesHelper
    {
        public static class Skills
        {
            public static Texture2D TowerPlacerImage => Resources.Load<Texture2D>("Skills/Skill.Stone.Add");
            public static Texture2D TowerRemoverImage => Resources.Load<Texture2D>("Skills/Skill.Stone.Remove");
        }
    }
}