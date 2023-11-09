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
        /// Get all legal moves for a <see cref="DiscType"/>
        /// </summary>
        /// <param name="discType">The <see cref="DiscType"/> to find legal moves for</param>
        /// <returns>A list of spaces representing legal moves</returns>
        public IList<Vector2D> GetLegalMoves(DiscType discType)
        {
            var legalSpaces = new List<Vector2D>();

            IEnumerable<DiscSpace> spacesToTraceFrom = Controls.Cast<DiscSpace>();

            foreach (DiscSpace initialSpace in
                spacesToTraceFrom
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
            int currentColumn = initialSpace.Column + directionVector.Column * 2;
            int currentRow = initialSpace.Row + directionVector.Row * 2;
            var currentPosition = new Vector2D(currentColumn, currentRow);

            DiscSpace currentSpace = null;
            while (PositionIsOnBoard(currentPosition))
            {
                currentSpace = GetDiscSpace(currentPosition);

                if (currentSpace.SpaceColor != DiscType.Empty)
                {
                    if (currentSpace.HasOppositeDiscColor(initialSpace.SpaceColor))
                    {
                        currentPosition += directionVector;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (GetPreviousDiscSpace(currentPosition, directionVector)
                        .HasOppositeDiscColor(initialSpace.SpaceColor))
                    {
                        return currentSpace;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            if (currentSpace != null)
            {
                DiscSpace previousSpace = GetPreviousDiscSpace(currentPosition, directionVector);

                if (previousSpace.SpaceColor != initialSpace.SpaceColor)
                {
                    return currentSpace;
                }
            }

            return null;
        }

        public DiscSpace GetPreviousDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition - directionVector);
        }
    }
}
