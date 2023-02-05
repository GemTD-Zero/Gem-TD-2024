using UnityEngine.EventSystems;

namespace _src.Extensions
{
    public static class Helpers
    {
        public static bool IsMouseOverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}