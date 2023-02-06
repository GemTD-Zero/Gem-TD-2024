using _src.Grid.Visual;

namespace _src.Grid
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

        public GridCell(CellPosition position, CellVisualMono visual, CellStatus status)
        {
            Position = position;
            this.visual = visual;
            Status = status;
        }

        public CellStatus Status { get; private set; }

        public CellPosition Position { get; }

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