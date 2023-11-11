using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfOthelloAssignment
{
    public class LegalMove
    {
        /// <summary>
        /// A position on the board where a disc can be placed
        /// </summary>
        public Vector2D PositionToPlaceDisc { get; set; }

        /// <summary>
        /// The direction in which opposite color discs that will be flipped
        /// </summary>
        public Vector2D FlankDirection { get; set; }

        public bool Equals(LegalMove obj)
        {
            return PositionToPlaceDisc.Equals(obj.PositionToPlaceDisc);
        }

        /// <summary>
        /// Implicit cast to Vector2D to represent a position on the board
        /// </summary>
        public static implicit operator Vector2D(LegalMove legalMove)
        {
            return legalMove.PositionToPlaceDisc;
        }
    }
}
