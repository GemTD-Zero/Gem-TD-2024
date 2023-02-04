using TMPro;
using UnityEngine;

namespace _src.Grid.Debug
{
    public class GridDebugMono : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro text;

        private GridCell cell;

        public void SetGridCell(GridCell o)
        {
            cell = o;
            text.text = cell.ToString();
        }
    }
}