using System.Diagnostics;

namespace GameOfOthelloAssignment
{
    [DebuggerDisplay("({Column},{Row})")]
    public class Vector2D
    {
        public int Column, Row;

        public Vector2D(int column, int row)
        {
            Column = column;
            Row = row;
        }

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
    }
}
