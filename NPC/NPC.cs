using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfOthelloAssignment.NPC
{
    public class NPC
    {
        public int SearchDepth { get; set; }

        public OthelloBoard othelloBoard { get; set; }

        public int MiniMax(Vector2D position, int depth, OthelloBoard othelloBoard, DiscType maximizingPlayerColor)
        {
            // Base case
            if (depth == 0 || othelloBoard.IsGameOver())
            {
                return othelloBoard.GetScoreForGivenColor(maximizingPlayerColor);
            }

            // Recurring case
            if (othelloBoard.CurrentTurnColor == maximizingPlayerColor)
            {
                int maxEval = int.MinValue;
                // loop through all possible legal moves
                    // recusive call to MiniMax with child, decremented depth, and 

            }


        }

    }
}
