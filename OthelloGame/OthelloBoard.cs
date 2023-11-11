﻿using GameOfOthelloAssignment.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    /// <summary>
    /// A gameboard in which Othello can be played
    /// </summary>
    public class OthelloBoard : TableLayoutPanel
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
        public FormDiscSpace GetDiscSpace(int column, int row)
        {
            return (FormDiscSpace)GetControlFromPosition(column, row);
        }

        /// <summary> Note: 0-based </summary>
        public FormDiscSpace GetDiscSpace(Vector2D position)
        {
            return (FormDiscSpace)GetControlFromPosition(position.Column, position.Row);
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
        public FormDiscSpace GetPreviousDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition - directionVector);
        }

        /// <summary>
        /// Get the next disc space in the direction of the given vector
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public FormDiscSpace GetNextDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition + directionVector);
        }

        /// <summary>
        /// Retrieve the current score for the given disc color
        /// </summary>
        public int GetScoreForGivenColor(DiscType color)
        {
            switch(color)
            {
                case DiscType.Black:
                    return BlackScore;
                case DiscType.White:
                    return WhiteScore;
                default:
                    return 0;
            }
        }

        public bool IsGameOver()
        {
            return BlackScore + WhiteScore >= 64;
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
                    FormDiscSpace discSpace = new FormDiscSpace(columnIndex, rowIndex);
                    discSpace.Click += PerformTurn;

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
            foreach (FormDiscSpace discSpace in Controls)
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

            foreach (FormDiscSpace initialSpace in
                Controls.Cast<FormDiscSpace>()
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
        /// <returns>The <see cref="FormDiscSpace"/> of a legal move if there is one, else return null</returns>
        private LegalMove GetLegalMoveForDirection(FormDiscSpace initialSpace, Vector2D directionVector)
        {
            // Move two spaces in the given direction
            var currentPosition = new Vector2D(
                column: initialSpace.Column + directionVector.Column * 2,
                row: initialSpace.Row + directionVector.Row * 2);

            while (PositionIsOnBoard(currentPosition))
            {
                FormDiscSpace currentSpace = GetDiscSpace(currentPosition);

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
        /// Flip all discs of the opposite color between the given disc and 
        /// the next disc of that same color in the given vector
        /// </summary>
        /// <param name="performedLegalMove">The legal move that caused pieces to be flanked</param>
        private void FlipDiscs(LegalMove performedLegalMove)
        {
            FormDiscSpace legalMoveSpace = GetDiscSpace(performedLegalMove);
            FormDiscSpace currentSpace = GetDiscSpace(performedLegalMove + performedLegalMove.FlankDirection);
            while (currentSpace.HasOppositeDiscColor(legalMoveSpace.DiscColor))
            {
                // Flip the disc 
                GetDiscSpace(currentSpace).SetDisc(legalMoveSpace.DiscColor);

                // Update score
                if (legalMoveSpace.DiscColor == DiscType.Black)
                {
                    WhiteScore--;
                    BlackScore ++;
                }
                else
                {

                    BlackScore--;
                    WhiteScore++;
                }

                currentSpace = GetNextDiscSpace(currentSpace, performedLegalMove.FlankDirection);
            }
        }

        /// <summary>
        /// When a player clicks a space to place a disc into,
        /// </summary>
        private void PerformTurn(object sender, EventArgs eventArgs)
        {
            FormDiscSpace clickedSpace = (FormDiscSpace)sender;
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
        }

        private void SwitchTurns()
        {
            switch (CurrentTurnColor)
            {
                case DiscType.Black:
                    CurrentTurnColor = DiscType.White; break;
                case DiscType.White:
                    CurrentTurnColor = DiscType.Black; break;
            }
            
            EnableLegalMoves();
            
            TurnFinished();
        }

        #endregion

        #region Events
        public event Action TurnFinished;
        #endregion

    }
}
