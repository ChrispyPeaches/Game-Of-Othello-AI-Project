using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using GameOfOthelloAssignment.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameOfOthelloAssignment.Controls
{
    /// <summary>
    /// A gameboard in which Othello can be played
    /// </summary>
    public class ControlOthelloBoard : TableLayoutPanel
    {
        /// <summary>
        /// The color of the player or AI whose turn it is
        /// </summary>
        public DiscType CurrentTurnColor;

        public int BlackScore { get; set; } = 0;
        public int WhiteScore { get; set; } = 0;

        /// <summary>
        /// The moves that the current player or AI is allowed to perform
        /// </summary>
        private IList<LegalMove> CurrentLegalMoves;

        public DiscType Player1DiscColor { get; set; }
        public GameMode gameMode { get; set; }

        #region Helper Methods

        /// <summary> Note: 0-based </summary>
        public ControlDiscSpace GetDiscSpace(int column, int row)
        {
            return (ControlDiscSpace)GetControlFromPosition(column, row);
        }

        /// <summary> Note: 0-based </summary>
        public ControlDiscSpace GetDiscSpace(Vector2D position)
        {
            return (ControlDiscSpace)GetControlFromPosition(position.Column, position.Row);
        }

        /// <summary>
        /// Check if the given position is within the limits of an 8x8 othello board
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private static bool PositionIsOnBoard(Vector2D position)
        {
            if (0 <= position.Column && position.Column < 8 &&
                   0 <= position.Row && position.Row < 8)
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
        public ControlDiscSpace GetPreviousDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition - directionVector);
        }

        /// <summary>
        /// Get the next disc space in the direction of the given vector
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public ControlDiscSpace GetNextDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition + directionVector);
        }

        /// <summary>
        /// Retrieve the current score for the given disc color
        /// </summary>
        public int GetScoreForGivenColor(DiscType color)
        {
            switch (color)
            {
                case DiscType.Black:
                    return BlackScore;
                case DiscType.White:
                    return WhiteScore;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Determine whether the game is over depending on the current scores 
        /// & whether there's any legal moves left
        /// </summary>
        public bool IsGameOver()
        {
            bool isScoreMax = BlackScore + WhiteScore >= 64;
            bool noLegalCurrentTurnMoves = false;
            bool noLegalNextMoves = false;

            // If the score isn't at max, check if there are any legal moves left
            if (!isScoreMax)
            {
                noLegalCurrentTurnMoves = CurrentLegalMoves.Count <= 0;
                // Aren't any current legal moves, check if there are any on the next turn
                if (noLegalCurrentTurnMoves)
                {
                    noLegalNextMoves = 
                        GetLegalMoves(ControlDiscSpace.GetOppositeDiscColor(CurrentTurnColor)).Count <= 0;
                }
            }
            return isScoreMax || noLegalCurrentTurnMoves && noLegalNextMoves;
        }

        public DiscType GetCurrentlyWinningColor()
        {
            return (BlackScore > WhiteScore) ?
                DiscType.Black
                : DiscType.White;
        }

        #endregion

        #region Game logic

        public void BoardSetup()
        {
            // Add containers for each space on the board
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    ControlDiscSpace discSpace = new ControlDiscSpace(columnIndex, rowIndex);
                    discSpace.Click += OnSpaceClick;

                    Controls.Add(discSpace, columnIndex, rowIndex);
                }
            }

            GameSetup();
        }

        /// <summary> 
        /// Clear the game board, add the starting discs to the game, and show legal moves.
        /// </summary>
        private void GameSetup()
        {
            ClearGameBoard();

            GetDiscSpace(3, 3).SetDisc(DiscType.White);
            GetDiscSpace(4, 3).SetDisc(DiscType.Black);
            GetDiscSpace(3, 4).SetDisc(DiscType.Black);
            GetDiscSpace(4, 4).SetDisc(DiscType.White);
            BlackScore = 2;
            WhiteScore = 2;

            CurrentTurnColor = DiscType.Black;
            EnableLegalMoves();
        }

        /// <summary>
        /// Clear all spaces on the board
        /// </summary>
        private void ClearGameBoard()
        {
            foreach (ControlDiscSpace discSpace in Controls)
            {
                discSpace.SetDisc(DiscType.Empty);
            }
        }

        /// <summary>
        /// Get all legal moves for a <see cref="DiscType"/>(color)
        /// </summary>
        /// <param name="discType">The <see cref="DiscType"/>(color) to find legal moves for</param>
        /// <returns>A list of spaces representing legal moves</returns>
        private IList<LegalMove> GetLegalMoves(DiscType discType)
        {
            if (discType == DiscType.Empty)
            {
                throw new NotSupportedException();
            }

            var legalMoves = new List<LegalMove>();

            foreach (ControlDiscSpace initialSpace in
                Controls.Cast<ControlDiscSpace>()
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
        /// <returns>The <see cref="ControlDiscSpace"/> of a legal move if there is one, else return null</returns>
        private LegalMove GetLegalMoveForDirection(ControlDiscSpace initialSpace, Vector2D directionVector)
        {
            // Move two spaces in the given direction
            var currentPosition = new Vector2D(
                column: initialSpace.Column + directionVector.Column * 2,
                row: initialSpace.Row + directionVector.Row * 2);

            while (PositionIsOnBoard(currentPosition))
            {
                ControlDiscSpace currentSpace = GetDiscSpace(currentPosition);

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
                            PositionToPlaceDisc = currentSpace
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
        /// Allows board spaces representing legal moves for the current turn's color to be interacted with
        /// </summary>
        private void EnableLegalMoves()
        {
            CurrentLegalMoves = GetLegalMoves(CurrentTurnColor);
            foreach (LegalMove legalMove in CurrentLegalMoves)
            {
                GetDiscSpace(legalMove).SetAsLegalMove(CurrentTurnColor);
            }
        }

        /// <summary>
        /// Removes ability to interact with previously legal moves
        /// </summary>
        private void DisableLegalMoves()
        {
            foreach (var legalMove in CurrentLegalMoves)
            {
                GetDiscSpace(legalMove).DiableLegalMove();
            }
        }

        /// <summary>
        /// Flip all discs of the opposite color between the given disc and 
        /// the next disc of that same color in every direction
        /// </summary>
        /// <param name="performedLegalMove">The legal move that caused pieces to be flanked</param>
        private void FlipDiscs(LegalMove performedLegalMove)
        {
            ControlDiscSpace legalMoveSpace = GetDiscSpace(performedLegalMove);
            for (int columnDirection = -1; columnDirection <= 1; columnDirection++)
            {
                for (int rowDireciton = -1; rowDireciton <= 1; rowDireciton++)
                {
                    // Skip directional vector <0,0>
                    if (columnDirection == 0 && rowDireciton == 0) continue;

                    FlipDiscsInDirection(
                        legalMoveSpace,
                        new Vector2D(columnDirection, rowDireciton));
                }
            }
        }

        private void FlipDiscsInDirection(ControlDiscSpace legalMoveSpace, Vector2D directionVector)
        {
            Vector2D currentPosition = new Vector2D(
                column: legalMoveSpace.Column + directionVector.Column,
                row: legalMoveSpace.Row + directionVector.Row);

            // Move in the given direction until you reach a piece of your same color
            while (PositionIsOnBoard(currentPosition))
            {
                ControlDiscSpace currentSpace = GetDiscSpace(currentPosition);

                // If the space has a piece in it
                if (currentSpace.DiscColor != DiscType.Empty)
                {
                    // If the piece is the opposite color of the current turn
                    if (currentSpace.HasOppositeDiscColor(legalMoveSpace.DiscColor))
                    {
                        // Look forward one more space in the given direction
                        currentPosition += directionVector;
                        continue;
                    }
                    // If the piece is the same color of the current turn
                    else
                    {
                        break;
                    }
                }
                // If the space is empty
                else
                {
                    return;
                }
            }
            if (!PositionIsOnBoard(currentPosition))
            {
                return;
            }

            // If a piece of the same color was not found in the given direction, don't flip any discs
            if (GetDiscSpace(currentPosition).HasOppositeDiscColor(legalMoveSpace.DiscColor))
            {
                return;
            }
            // Otherwise, work backwards and flip every disc until running
            // into a piece of the same color as the legal move
            else
            {
                directionVector = directionVector * -1;
                currentPosition += directionVector;
                while (PositionIsOnBoard(currentPosition))
                {
                    ControlDiscSpace currentSpace = GetDiscSpace(currentPosition);

                    // If the space has a piece in it
                    if (currentSpace.DiscColor != DiscType.Empty)
                    {
                        // If the piece is the opposite color of the current turn
                        if (currentSpace.HasOppositeDiscColor(legalMoveSpace.DiscColor))
                        {
                            // Look forward one more space in the given direction// Flip the disc 
                            FlipDisc(currentPosition, legalMoveSpace.DiscColor);
                            currentPosition += directionVector;
                            continue;
                        }
                        // If the piece is the same color of the current turn
                        else
                        {
                            break;
                        }
                    }
                    // If the space is empty
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void FlipDisc(Vector2D discToFlipPosition, DiscType colorToFlipTo)
        {
            // Flip the disc 
            GetDiscSpace(discToFlipPosition).SetDisc(colorToFlipTo);

            // Update score
            if (colorToFlipTo == DiscType.Black)
            {
                WhiteScore--;
                BlackScore++;
            }
            else
            {

                BlackScore--;
                WhiteScore++;
            }
        }

        /// <summary>
        /// If in AI mode, verify the player can only move on their turn
        /// </summary>
        public void OnSpaceClick(object clickedSpace, EventArgs eventArgs)
        {
            if (gameMode == GameMode.TwoPlayer || Player1DiscColor == CurrentTurnColor)
            {
                PerformTurn((ControlDiscSpace)clickedSpace);
            }
        }

        /// <summary>
        /// When a player clicks a space to place a disc into,
        /// </summary>
        public void PerformTurn(ControlDiscSpace clickedSpace)
        {
            DisableLegalMoves();
            GetDiscSpace(clickedSpace).SetDisc(CurrentTurnColor);
            // Update score
            if (CurrentTurnColor == DiscType.Black)
            {
                BlackScore++;
            }
            else
            {
                WhiteScore++;
            }

            FlipDiscs(CurrentLegalMoves.First(move => move.PositionToPlaceDisc.Equals(clickedSpace)));
            SwitchTurns();
            EnableLegalMoves();

            // If the game is over, trigger the Game Over event
            if (IsGameOver())
            {
                GameOver();
            }

            // Trigger the Turn Finished event
            TurnFinished();
        }

        /// <summary>
        /// Switch the current turn to the opposite color
        /// </summary>
        private void SwitchTurns()
        {
            CurrentTurnColor = ControlDiscSpace.GetOppositeDiscColor(CurrentTurnColor);
        }

        #endregion

        #region Events
        public event Action TurnFinished;
        public event Action GameOver;
        #endregion

    }
}
