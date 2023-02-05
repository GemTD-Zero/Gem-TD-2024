using TMPro;
using UnityEngine;

namespace _src.Extensions
{
    public static class ActivePassiveObjectExtensions
    {
        public static void SetActivated(this MonoBehaviour o)
        {
            o.gameObject.SetActive(true);
        }

        public static void SetDisabled(this MonoBehaviour o)
        {
            o.gameObject.SetActive(false);
        }
        
    }
}