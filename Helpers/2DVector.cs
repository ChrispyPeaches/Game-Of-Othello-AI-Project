using System.Diagnostics;

namespace GameOfOthelloAssignment.Helpers
{
    public class Vector2D
    {
        public int Column, Row;

        public Vector2D(int column, int row)
        {
            Column = column;
            Row = row;
        }

        #region Math Operator Overloading

        public static Vector2D operator +(Vector2D initialVector, Vector2D addingVector)
        {
            return new Vector2D(
                    initialVector.Column + addingVector.Column,
                    initialVector.Row + addingVector.Row
                    );
        }

        public static Vector2D operator -(Vector2D initialVector, Vector2D subtractingVector)
        {
            return new Vector2D(
                    initialVector.Column - subtractingVector.Column,
                    initialVector.Row - subtractingVector.Row
                    );
        }
        public static Vector2D operator *(Vector2D initialVector, int scalarMultiple)
        {
            return new Vector2D(
                    initialVector.Column * scalarMultiple,
                    initialVector.Row * scalarMultiple
                    );
        }

        #endregion

        #region Equality Operator Overloading

        public static bool operator <(Vector2D initialVector, Vector2D otherVector)
        {
            return initialVector.Column < otherVector.Column &&
                    initialVector.Row < otherVector.Row;
        }

        public static bool operator >(Vector2D initialVector, Vector2D otherVector)
        {
            return initialVector.Column > otherVector.Column &&
                    initialVector.Row > otherVector.Row;
        }

        public static bool operator <=(Vector2D initialVector, Vector2D otherVector)
        {
            return initialVector.Column <= otherVector.Column &&
                    initialVector.Row <= otherVector.Row;
        }

        public static bool operator >=(Vector2D initialVector, Vector2D otherVector)
        {
            return initialVector.Column >= otherVector.Column &&
                    initialVector.Row >= otherVector.Row;
        }

        #endregion

        public bool Equals(Vector2D otherVector)
        {
            return Column == otherVector.Column &&
                    Row == otherVector.Row;
        }

        public override string ToString()
        {
            return $"({Column},{Row})";
        }
    }
}
