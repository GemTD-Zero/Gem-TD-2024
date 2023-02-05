namespace _src.Grid
{
    public class GridCell
    {
        public GridCell(CellPosition position)
        {
            Position = position;
        }

        public CellPosition Position { get; }
        
        

        public override string ToString()
        {
            return Position.ToString();
        }
    }
}