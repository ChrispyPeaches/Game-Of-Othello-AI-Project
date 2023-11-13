using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using System;
using System.Collections.Generic;

namespace GameOfOthelloAssignment.NPC
{
    public class NPC
    {   
        /// <summary>
        /// Perform the minimax algorithm on the given game state
        /// </summary>
        public static MiniMaxResult MiniMax(
            NpcOthelloBoard gameState,
            int depth,
            int alpha,
            int beta,
            DiscType maximizingPlayerColor,
            bool pruningEnabled)
        {
            // Base case
            if (depth == 0 || gameState.IsGameOver())
            {
                return new MiniMaxResult()
                {
                    ExtremeScoreEval = gameState.GetHeuristicScoreForGivenColor(maximizingPlayerColor),
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
                foreach (Vector2D legalMove in gameState.CurrentLegalMoves)
                {
                    // Clone the game state, play the move on it, and evaluate the further possible moves
                    DiscType legalMoveColor = gameState.CurrentTurnColor;
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    MiniMaxResult result = MiniMax(childGameState, depth - 1, alpha, beta, maximizingPlayerColor, pruningEnabled);
                    result.DiscColor = legalMoveColor;
                    result.Position = legalMove;
                    ParentResult.ChildMoves.Add(result);

                    // Maximizing & Pruning
                    if (result.ExtremeScoreEval > ParentResult.ExtremeScoreEval)
                    {
                        ParentResult.ExtremeResult = result;
                        ParentResult.ExtremeScoreEval = result.ExtremeScoreEval;
                    }
                    if (pruningEnabled)
                    {
                        alpha = Math.Max(alpha, result.ExtremeScoreEval);
                        if (beta <= alpha)
                        {
                            break;
                        }
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
                foreach (Vector2D legalMove in gameState.CurrentLegalMoves)
                {
                    // Clone the game state, play the move on it, and evaluate the further possible moves
                    DiscType legalMoveColor = gameState.CurrentTurnColor;
                    var childGameState = CloneHelper.CloneFromNPCBoardToNPCBoard(gameState);
                    childGameState.PerformTurn(legalMove);
                    MiniMaxResult result = MiniMax(childGameState, depth - 1, alpha, beta, maximizingPlayerColor, pruningEnabled);
                    result.DiscColor = legalMoveColor;
                    result.Position = legalMove;
                    ParentResult.ChildMoves.Add(result);

                    // Minimizing & Pruning
                    if (result.ExtremeScoreEval < ParentResult.ExtremeScoreEval)
                    {
                        ParentResult.ExtremeResult = result;
                        ParentResult.ExtremeScoreEval = result.ExtremeScoreEval;
                    }
                    if (pruningEnabled)
                    {
                        beta = Math.Min(beta, result.ExtremeScoreEval);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }
                return ParentResult;
            }
        }

        /// <summary>
        /// Print header with details about the current simulated sequence
        /// </summary>
        /// <param name="parentResult">The minimax result to print sequences for</param>
        public static void PrintSequencesHelper(MiniMaxResult parentResult)
        {
            Console.WriteLine($"=============== NEW MOVE ===============");
            foreach (var childMove in parentResult.ChildMoves)
            {
                Console.WriteLine($"Heuristic Score: {childMove.ExtremeScoreEval}");
                Console.WriteLine($"Initial Move: {childMove.Position}");
                PrintSequences(childMove, "");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print the sequence of move positions for the given minimax result
        /// </summary>
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

    /// <summary>
    /// The result from performing the minimax algorithm on a gamestate
    /// </summary>
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

        /// <summary>
        /// The disc color that is placed in the position
        /// </summary>
        public DiscType DiscColor { get; set; }

        /// <summary>
        /// The minimum or maximum result from the list of child moves
        /// </summary>
        public MiniMaxResult ExtremeResult { get; set; }

        /// <summary>
        /// The list of child moves in relation to the result's move
        /// </summary>
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
