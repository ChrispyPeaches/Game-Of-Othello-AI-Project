using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfOthelloAssignment.NPC
{
    public class NPC
    {
        public static Vector2D MiniMaxHelper(
            NpcOthelloBoard gameState,
            int depth,
            DiscType maximizingPlayerColor)
        {
            int maxEval = int.MinValue;
            Vector2D bestPosition = null;
            foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
            {
                var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                childGameState.PerformTurn(legalMove);
                int eval = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                if (eval > maxEval)
                {
                    bestPosition = legalMove;
                    maxEval = eval;
                }
            }
            return bestPosition;
        }
        
        public static int MiniMax(
            NpcOthelloBoard gameState,
            int depth,
            DiscType maximizingPlayerColor)
        {
            // Base case
            if (depth == 0 || gameState.IsGameOver())
            {
                return gameState.GetScoreForGivenColor(maximizingPlayerColor);
            }

            // Recurring case
            if (gameState.CurrentTurnColor == maximizingPlayerColor)
            {
                int maxEval = int.MinValue;
                foreach(LegalMove legalMove in gameState.CurrentLegalMoves)
                {
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    int eval = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                    maxEval = Math.Max(eval, maxEval);
                }
                return maxEval;
            }
            else
            {
                int minEval = int.MaxValue;
                foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
                {
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    int eval = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                    minEval = Math.Min(minEval, eval);
                }
                return minEval;
            }
        }
    }
}
