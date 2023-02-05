using UnityEngine;

namespace _src.Grid.Visual
{
    public class CellVisualMono : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer mouseOverRenderer;

        [SerializeField]
        private MeshRenderer normalRenderer;

        [SerializeField]
        private MeshRenderer selectedRenderer;

        private void Awake()
        {
            ShowNormal();
        }


        public void ShowNormal()
        {
            normalRenderer.enabled = true;
            selectedRenderer.enabled = false;
            mouseOverRenderer.enabled = false;
        }

        public void ShowSelected()
        {
            normalRenderer.enabled = false;
            selectedRenderer.enabled = true;
            mouseOverRenderer.enabled = false;
        }

        public void ShowMouseOver()
        {
            normalRenderer.enabled = false;
            selectedRenderer.enabled = false;
            mouseOverRenderer.enabled = true;
        }

        public void Hide()
        {
            normalRenderer.enabled = false;
            selectedRenderer.enabled = false;
            mouseOverRenderer.enabled = false;
        }
    }
}