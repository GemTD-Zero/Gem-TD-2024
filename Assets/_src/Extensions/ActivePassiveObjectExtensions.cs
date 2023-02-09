using UnityEngine;

namespace _src.Extensions
{
    public static class ActivePassiveObjectExtensions
    {
        public static void SetActivated(this MonoBehaviour o)
        {
            o.gameObject.SetActive(true);
        }

        public static void SetDeactivated(this MonoBehaviour o)
        {
            o.gameObject.SetActive(false);
        }
        
        public static void SetActivated(this Transform o)
        {
            o.gameObject.SetActive(true);
        }

        public static void SetDeactivated(this Transform o)
        {
            o.gameObject.SetActive(false);
        }

        public static bool IsActivated(this Transform o)
        {
            return o.gameObject.activeSelf;
        }
    }
}