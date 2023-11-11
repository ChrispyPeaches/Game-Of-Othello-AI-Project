using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfOthelloAssignment.NPC
{
    public class NPC
    {
        public static MiniMaxResult MiniMaxHelper(
            NpcOthelloBoard gameState,
            int depth,
            DiscType maximizingPlayerColor)
        {
            MiniMaxResult BestResult = new MiniMaxResult()
            {
                ScoreEval = int.MinValue,
                Position = null
            };
            foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
            {
                DiscType legalMoveColor = gameState.CurrentTurnColor;
                var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                childGameState.PerformTurn(legalMove);
                MiniMaxResult result = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                if (result.ScoreEval > BestResult.ScoreEval)
                {
                    result.DiscColor = legalMoveColor;
                    result.Position = legalMove;
                    BestResult = result;
                }
            }
            BestResult.ChildMoves.Add(BestResult);
            return BestResult;
        }
        
        public static MiniMaxResult MiniMax(
            NpcOthelloBoard gameState,
            int depth,
            DiscType maximizingPlayerColor)
        {
            // Base case
            if (depth == 0 || gameState.IsGameOver())
            {
                return new MiniMaxResult()
                {
                    ScoreEval = gameState.GetScoreForGivenColor(maximizingPlayerColor),
                    Position = null
                };
            }

            // Recurring case
            if (gameState.CurrentTurnColor == maximizingPlayerColor)
            {
                MiniMaxResult BestResult = new MiniMaxResult()
                {
                    ScoreEval = int.MinValue,
                    Position = null
                };
                foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
                {
                    DiscType legalMoveColor = gameState.CurrentTurnColor;
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    MiniMaxResult result = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                    if (result.ScoreEval > BestResult.ScoreEval)
                    {
                        result.DiscColor = legalMoveColor;
                        result.Position = legalMove;
                        BestResult = result;
                    }
                }
                BestResult.ChildMoves.Add(BestResult);
                return BestResult;
            }
            else
            {
                MiniMaxResult WorstResult = new MiniMaxResult()
                {
                    ScoreEval = int.MaxValue,
                    Position = null
                };
                foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
                {
                    DiscType legalMoveColor = gameState.CurrentTurnColor;
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    MiniMaxResult result = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                    if (result.ScoreEval < WorstResult.ScoreEval)
                    {
                        result.DiscColor = legalMoveColor;
                        result.Position = legalMove;
                        WorstResult = result;
                    }
                }
                WorstResult.ChildMoves.Add(WorstResult);
                return WorstResult;
            }
        }
    }

    public class MiniMaxResult
    {
        /// <summary>
        /// The position moved into
        /// </summary>
        public int ScoreEval { get; set; }

        /// <summary>
        /// The position moved into that caused the result's score eval
        /// </summary>
        public Vector2D Position { get; set; }

        public DiscType DiscColor { get; set; }

        public IList<MiniMaxResult> ChildMoves { get; set; } = new List<MiniMaxResult>();
    }
}
