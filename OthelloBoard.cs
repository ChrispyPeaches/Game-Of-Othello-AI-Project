using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public class OthelloBoard : TableLayoutPanel
    {
        public int BlackScore { get; set; } = 0;
        public int WhiteScore { get; set; } = 0;

        /// <summary> Note: 0-based </summary>
        public DiscSpace GetDiscSpace(int column, int row)
        {
            return (DiscSpace)GetControlFromPosition(column, row);
        }

        /// <summary> Note: 0-based </summary>
        public DiscSpace GetDiscSpace(Vector2D position)
        {
            return (DiscSpace)GetControlFromPosition(position.Column, position.Row);
        }

        /// <summary>
        /// Get all legal moves for a <see cref="DiscType"/>(color)
        /// </summary>
        /// <param name="discType">The <see cref="DiscType"/>(color) to find legal moves for</param>
        /// <returns>A list of spaces representing legal moves</returns>
        public IList<LegalMove> GetLegalMoves(DiscType discType)
        {
            if (discType == DiscType.Empty)
            {
                throw new NotSupportedException();
            }

            var legalMoves = new List<LegalMove>();

            foreach (DiscSpace initialSpace in
                Controls.Cast<DiscSpace>()
                .Where(s => s.DiscColor == discType))
            {
                for (int columnDirection = -1; columnDirection <= 1; columnDirection++)
                {
                    for (int rowDireciton = -1; rowDireciton <= 1; rowDireciton++)
                    {
                        // Skip directional vector <0,0>
                        if (columnDirection == 0 && rowDireciton == 0) continue;

                        LegalMove legalOrNullMove = GetLegalMoveForDirection(
                            initialSpace,
                            new Vector2D(columnDirection, rowDireciton));

                        // If it is a legal move
                        if (legalOrNullMove != null)
                        {
                            // Add it to the legal moves
                            legalMoves.Add(legalOrNullMove);
                        }
                    }
                }
            }

            // Ensures there are no repeated legal moves
            legalMoves = legalMoves.Distinct().ToList();

            return legalMoves;
        }

        /// <summary>
        /// Find if there is a legal move in the given direction
        /// </summary>
        /// <param name="initialSpace"></param>
        /// <param name="directionVector"></param>
        /// <returns>The <see cref="DiscSpace"/> of a legal move if there is one, else return null</returns>
        public LegalMove GetLegalMoveForDirection(DiscSpace initialSpace, Vector2D directionVector)
        {
            // Move two spaces in the given direction
            var currentPosition = new Vector2D(
                column: initialSpace.Column + directionVector.Column * 2,
                row: initialSpace.Row + directionVector.Row * 2);

            while (PositionIsOnBoard(currentPosition))
            {
                DiscSpace currentSpace = GetDiscSpace(currentPosition);

                // If the space has a piece in it
                if (currentSpace.DiscColor != DiscType.Empty)
                {
                    // If the piece is the opposite color of the current turn
                    if (currentSpace.HasOppositeDiscColor(initialSpace.DiscColor))
                    {
                        // Look forward one more space in the given direction
                        currentPosition += directionVector;
                        continue;
                    }
                    // If the piece is the same color of the current turn
                    else
                    {
                        // This is an ILLEGAL move
                        return null;
                    }
                }
                // If the space is empty
                else
                {
                    // If the piece before this one (in the given direction) is the opposite color
                    if (GetPreviousDiscSpace(currentPosition, directionVector)
                        .HasOppositeDiscColor(initialSpace.DiscColor))
                    {
                        // This is a LEGAL move
                        return new LegalMove()
                        {
                            PositionToPlaceDisc = currentSpace,
                            FlankDirection = directionVector * -1
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            // If the position is outside of the board,
            // this is an ILLEGAL move
            return null;
        }

        /// <summary>
        /// Check if the given position is within the limits of an 8x8 othello board
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool PositionIsOnBoard(Vector2D position)
        {
            if (0 <= position.Column && position.Column < ColumnCount &&
                   0 <= position.Row && position.Row < RowCount)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Get the next disc space in the opposite direction of the given vector
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public DiscSpace GetPreviousDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition - directionVector);
        }

        /// <summary>
        /// Get the next disc space in the direction of the given vector
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public DiscSpace GetNextDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition + directionVector);
        }

        public void FlipDiscs(LegalMove performedLegalMove)
        {
            DiscSpace legalMoveSpace = GetDiscSpace(performedLegalMove);
            DiscSpace currentSpace = GetDiscSpace(performedLegalMove + performedLegalMove.FlankDirection);
            while (currentSpace.HasOppositeDiscColor(legalMoveSpace.DiscColor))
            {
                // Flip the disc
                GetDiscSpace(currentSpace).SetDisc(legalMoveSpace.DiscColor);

                currentSpace = GetNextDiscSpace(currentSpace, performedLegalMove.FlankDirection);
            }
        }
    }
}
