using _src.Grid.Visual;
using _src.Towers.Stone;

namespace _src.Grid.Models
{
    public enum CellStatus
    {
        Normal,
        Hidden,
        MouseHover,
        Selected
    }

    public class GridCell
    {
        private readonly CellVisualMono visual;

        public GridCell(GridPosition position, CellVisualMono visual, CellStatus status)
        {
            Position = position;
            this.visual = visual;
            Status = status;
        }

        public CellStatus Status { get; private set; }

        public GridPosition Position { get; }

        public TowerMono Tower { get; set; }

        public void Select()
        {
            Log($"{Position.ToString()} Selected");
            Status = CellStatus.Selected;
            visual.ShowSelected();
        }

        public void Unselect()
        {
            Log($"{Position.ToString()} Unselected");
            Status = CellStatus.Normal;
            visual.ShowNormal();
        }

        public void Hide()
        {
            Log($"{Position.ToString()} Hidden");
            Status = CellStatus.Hidden;
            visual.Hide();
        }

        public void MouseHover()
        {
            Log($"{Position.ToString()} Mousehover");
            Status = CellStatus.MouseHover;
            visual.ShowMouseOver();
        }


        public override string ToString()
        {
            return Position.ToString();
        }

        private static void Log(string message)
        {
            //Debug.Log(message);
        }
    }
}