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

        public DiscSpace GetDiscSpace(Vector2D position)
        {
            return (DiscSpace)GetControlFromPosition(position.Column, position.Row);
        }

        /// <summary>
        /// Get all legal moves for a <see cref="DiscType"/>(color)
        /// </summary>
        /// <param name="discType">The <see cref="DiscType"/>(color) to find legal moves for</param>
        /// <returns>A list of spaces representing legal moves</returns>
        public IList<Vector2D> GetLegalMoves(DiscType discType)
        {
            if (discType == DiscType.Empty)
            {
                throw new NotSupportedException();
            }

            var legalSpaces = new List<Vector2D>();

            IEnumerable<DiscSpace> spacesToTraceFrom = ;

            foreach (DiscSpace initialSpace in
                Controls.Cast<DiscSpace>()
                .Where(s => s.SpaceColor == discType))
            {
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0) continue;

                        DiscSpace legalOrNullMove = GetLegalMoveForDirection(initialSpace, new Vector2D(x, y));
                        if (legalOrNullMove != null)
                        {
                            legalSpaces.Add(legalOrNullMove);
                        }
                    }
                }
            }

            legalSpaces = legalSpaces.Distinct().ToList();

            return legalSpaces;
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
        /// Find if there is a legal move in the given direction
        /// </summary>
        /// <param name="initialSpace"></param>
        /// <param name="directionVector"></param>
        /// <returns>The <see cref="DiscSpace"/> of a legal move if there is one, else return null</returns>
        public DiscSpace GetLegalMoveForDirection(DiscSpace initialSpace, Vector2D directionVector)
        {
            // Move two spaces in the given direction
            var currentPosition = new Vector2D(
                column: initialSpace.Column + directionVector.Column * 2,
                row: initialSpace.Row + directionVector.Row * 2);

            while (PositionIsOnBoard(currentPosition))
            {
                currentSpace = GetDiscSpace(currentPosition);

                // If the space has a piece in it
                if (currentSpace.SpaceColor != DiscType.Empty)
                {
                    // If the piece is the opposite color of the current turn
                    if (currentSpace.HasOppositeDiscColor(initialSpace.SpaceColor))
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
                        .HasOppositeDiscColor(initialSpace.SpaceColor))
                    {
                        // This is a LEGAL move
                        return currentSpace;
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
        /// Get the disc space in the opposite direction of the given vector
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public DiscSpace GetPreviousDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition - directionVector);
        }
    }
}
