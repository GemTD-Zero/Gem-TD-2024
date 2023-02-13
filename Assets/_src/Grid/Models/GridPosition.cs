using System;

namespace _src.Grid.Models
{
    [Serializable]
    public readonly struct GridPosition : IEquatable<GridPosition>
    {
        public GridPosition(int x, int z)
        {
            X = x;
            Z = z;
        }

        public int X { get; }

        public int Z { get; }

        public bool Equals(GridPosition other)
        {
            return X == other.X && Z == other.Z;
        }

        public override bool Equals(object o)
        {
            if (o is not GridPosition other)
            {
                return false;
            }

            return Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Z);
        }

        public override string ToString()
        {
            return $"{nameof(X)}:{X} {nameof(Z)}:{Z}";
        }

        public static bool operator ==(GridPosition a, GridPosition b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GridPosition a, GridPosition b)
        {
            return !a.Equals(b);
        }

        public static GridPosition operator +(GridPosition a, GridPosition b)
        {
            return new GridPosition(a.X + b.X, a.Z + b.Z);
        }

        public static GridPosition operator -(GridPosition a, GridPosition b)
        {
            return new GridPosition(a.X - b.X, a.Z - b.Z);
        }
    }
}