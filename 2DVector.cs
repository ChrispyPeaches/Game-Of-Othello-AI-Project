using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameOfOthelloAssignment
{
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
            initialVector.Column += addingVector.Column;
            initialVector.Row += addingVector.Row;
            return initialVector;
        }
    }
}
