using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public class OthelloBoard : TableLayoutPanel
    {
        public new TableLayoutDiscSpaceCollection Controls { get; set; }

        /// <summary>
        /// Note: 0-based
        /// </summary>
        public ref DiscSpace GetDiscSpace(int row, int column)
        {
            return ref GetControlFromPosition(column, row);
        }

        /// <summary>
        /// Get all legal moves for a <see cref="DiscType"/>
        /// </summary>
        /// <param name="discType">The <see cref="DiscType"/> to find legal moves for</param>
        /// <returns>A list of spaces representing legal moves</returns>
        public IList<DiscSpace> GetLegalMoves(DiscType discType)
        {
            var legalSpaces = new List<DiscSpace>();

            IEnumerable<DiscSpace> spacesToTraceFrom = Controls.Cast<DiscSpace>();

            foreach (DiscSpace initialSpace in
                spacesToTraceFrom
                .Where(s => s.CurrentDisc != null)
                .Where(s => s.CurrentDisc.Color == discType))
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
        /// If there is a legal move in the given direction
        /// </summary>
        /// <param name="initialSpace"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public DiscSpace GetLegalMoveForDirection(DiscSpace initialSpace, Vector2D directionVector)
        {
            int currentRow = initialSpace.Row + directionVector.Row;
            int currentColumn = initialSpace.Column + directionVector.Column;

            DiscSpace currentSpace = null;
            while (0 <= currentRow && currentRow < RowCount &&
                   0 <= currentColumn && currentColumn < ColumnCount)
            {
                currentSpace = this.GetDiscSpace(currentRow, currentColumn);
                if (currentSpace.CurrentDisc != null)
                {
                    if (currentSpace.CurrentDisc.Color == initialSpace.CurrentDisc.Color)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

                currentRow += directionVector.Row;
                currentColumn += directionVector.Column;
            }

            if (currentSpace != null)
            {
                DiscSpace previousSpace = 
                    GetDiscSpace(
                        currentRow - directionVector.Row,
                        currentColumn - directionVector.Column);

                if (previousSpace.CurrentDisc != null)
                {
                    if (previousSpace.CurrentDisc.Color != initialSpace.CurrentDisc.Color)
                    {
                        return currentSpace;
                    }
                }
            }

            return null;
        }
    }
}
