using System;

namespace _src.Grid
{
    public readonly struct CellPosition : IEquatable<CellPosition>
    {
        public CellPosition(int x, int z)
        {
            X = x;
            Z = z;
        }

        public int X { get; }

        public int Z { get; }

        public bool Equals(CellPosition other)
        {
            return X == other.X && Z == other.Z;
        }

        public override bool Equals(object o)
        {
            if (o is not CellPosition other)
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

        public static bool operator ==(CellPosition a, CellPosition b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(CellPosition a, CellPosition b)
        {
            return !a.Equals(b);
        }

        public static CellPosition operator +(CellPosition a, CellPosition b)
        {
            return new CellPosition(a.X + b.X, a.Z + b.Z);
        }

        public static CellPosition operator -(CellPosition a, CellPosition b)
        {
            return new CellPosition(a.X - b.X, a.Z - b.Z);
        }
    }
}