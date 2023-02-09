using System;
using UnityEngine;
namespace _src.Towers.TowerSelection
{
    public class TowerSelectionMono : MonoBehaviour
    {
        public Action<TowerSelectingStep> Activate { get; set; }

        private void Awake()
        {
            Debug.Log(nameof(TowerSelectionMono));
        }
    }
}