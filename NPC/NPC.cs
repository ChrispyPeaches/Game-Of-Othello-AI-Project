using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameOfOthelloAssignment.NPC
{
    public class NPC
    {
        public static MiniMaxResult MiniMaxHelper(
            NpcOthelloBoard gameState,
            int depth,
            DiscType maximizingPlayerColor)
        {
            MiniMaxResult ParentResult = new MiniMaxResult()
            {
                ExtremeScoreEval = int.MinValue,
                Position = null
            };
            foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
            {
                DiscType legalMoveColor = gameState.CurrentTurnColor;
                var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                childGameState.PerformTurn(legalMove);
                MiniMaxResult result = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                result.DiscColor = legalMoveColor;
                result.Position = legalMove;

                ParentResult.ChildMoves.Add(result);
                if (result.ExtremeScoreEval > ParentResult.ExtremeScoreEval)
                {
                    ParentResult.ExtremeResult = result;
                    ParentResult.ExtremeScoreEval = result.ExtremeScoreEval;
                }
            }
            return ParentResult;
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
                    ExtremeScoreEval = gameState.GetScoreForGivenColor(maximizingPlayerColor),
                    Position = null
                };
            }

            // Recurring case

            if (gameState.CurrentTurnColor == maximizingPlayerColor)
            {
                // Get Best Result (Maximize)
                MiniMaxResult ParentResult = new MiniMaxResult()
                {
                    ExtremeScoreEval = int.MinValue,
                    Position = null
                };
                foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
                {
                    DiscType legalMoveColor = gameState.CurrentTurnColor;
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    MiniMaxResult result = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                    result.DiscColor = legalMoveColor;
                    result.Position = legalMove;
                    ParentResult.ChildMoves.Add(result);

                    if (result.ExtremeScoreEval > ParentResult.ExtremeScoreEval)
                    {
                        ParentResult.ExtremeResult = result;
                        ParentResult.ExtremeScoreEval = result.ExtremeScoreEval;
                    }
                }
                return ParentResult;
            }
            else
            {
                // Get Worst Result (Minimize)
                MiniMaxResult ParentResult = new MiniMaxResult()
                {
                    ExtremeScoreEval = int.MaxValue,
                    Position = null
                };
                foreach (LegalMove legalMove in gameState.CurrentLegalMoves)
                {
                    DiscType legalMoveColor = gameState.CurrentTurnColor;
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    MiniMaxResult result = MiniMax(childGameState, depth - 1, maximizingPlayerColor);
                    result.DiscColor = legalMoveColor;
                    result.Position = legalMove;
                    ParentResult.ChildMoves.Add(result);

                    if (result.ExtremeScoreEval < ParentResult.ExtremeScoreEval)
                    {
                        ParentResult.ExtremeResult = result;
                        ParentResult.ExtremeScoreEval = result.ExtremeScoreEval;
                    }
                }
                return ParentResult;
            }
        }

        public static void PrintSequencesHelper(MiniMaxResult parentResult)
        {
            foreach (var childMove in parentResult.ChildMoves)
            {
                Console.WriteLine($"Heuristic Score: {childMove.ExtremeScoreEval}");
                Console.WriteLine($"Initial Move: {childMove.Position}");
                PrintSequences(childMove, "");
            }
        }

        public static void PrintSequences(MiniMaxResult parentResult, string parentMoves)
        {
            parentMoves += $" {parentResult.Position}";

            // Base Case
            if (parentResult.ChildMoves.Count == 0)
            {
                Console.WriteLine(parentMoves);
            }

            // Recursive Case
            foreach (var childMove in parentResult.ChildMoves)
            {
                PrintSequences(childMove, parentMoves + " ->");
            }
        }
    }

     public class MiniMaxResult
    {
        /// <summary>
        /// The extreme (minimum or maximum) result
        /// </summary>
        public int ExtremeScoreEval { get; set; }

        /// <summary>
        /// The position moved into that caused the result's score eval
        /// </summary>
        public Vector2D Position { get; set; }

        public DiscType DiscColor { get; set; }
        public MiniMaxResult ExtremeResult { get; set; }
        public IList<MiniMaxResult> ChildMoves { get; set; } = new List<MiniMaxResult>();

        public override string ToString()
        {
            return  $"Score:{ExtremeScoreEval} " +
                    $"|Position:{((Position != null) ? Position : "null")} " +
                    $"|Disc:{DiscColor} " +
                    $"|Children:{((ChildMoves != null) ? ChildMoves.Count : 0)}";
        }
    }
}
