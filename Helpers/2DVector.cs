using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameOfOthelloAssignment.Helpers
{
    [DebuggerDisplay("({Column}, {Row})")]
    public class Vector2D : IEquatable<Vector2D>
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

        public bool Equals(Vector2D otherVector)
        {
            if (otherVector is null) return otherVector is null;

            return Column == otherVector.Column &&
                    Row == otherVector.Row;
        }

        public override string ToString()
        {
            return $"({Column},{Row})";
        }
    }

    public class Vector2DComparer : IEqualityComparer<Vector2D>
    {
        public bool Equals(Vector2D initialVector, Vector2D otherVector) { return initialVector.Equals(otherVector); }

        public int GetHashCode(Vector2D obj) { return obj.ToString().GetHashCode(); }
    }
}
