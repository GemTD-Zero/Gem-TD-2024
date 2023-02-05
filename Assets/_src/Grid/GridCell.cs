using _src.Grid.Visual;

namespace _src.Grid
{
    public class GridCell
    {
        public GridCell(CellPosition position, CellVisualMono visual)
        {
            Position = position;
            Visual = visual;
        }

        public CellPosition Position { get; }

        public CellVisualMono Visual { get; }


        public override string ToString()
        {
            return Position.ToString();
        }
    }
}