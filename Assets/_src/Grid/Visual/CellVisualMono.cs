using UnityEngine;

namespace _src.Grid.Visual
{
    public class CellVisualMono : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer visual;

        public void Show()
        {
            visual.enabled = true;
        }

        public void Hide()
        {
            visual.enabled = false;
        }
    }
}