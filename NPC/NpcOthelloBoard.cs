﻿using GameOfOthelloAssignment.Controls;
using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace GameOfOthelloAssignment.NPC
{
    public class NpcOthelloBoard
    {
        /// <summary>
        /// The color of the player or AI whose turn it is
        /// </summary>
        public DiscType CurrentTurnColor;

        /// <summary>
        /// The amount of black discs on the board
        /// </summary>
        public int BlackScore { get; set; } = 0;

        /// <summary>
        ///  The amount of white discs on the board
        /// </summary>
        public int WhiteScore { get; set; } = 0;

        public IList<NpcDiscSpace> BoardSpaces { get; set; } = new List<NpcDiscSpace>();

        /// <summary>
        /// The moves that the current player or AI is allowed to perform
        /// </summary>
        public IList<Vector2D> CurrentLegalMoves;

        #region Helper Methods

        /// <summary> Note: 0-based </summary>
        public NpcDiscSpace GetDiscSpace(int column, int row)
        {
            return BoardSpaces.First(space => space.Column == column && space.Row == row);
        }

        /// <summary> Note: 0-based </summary>
        public NpcDiscSpace GetDiscSpace(Vector2D position)
        {
            return GetDiscSpace(position.Column, position.Row);
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
        /// <returns></returns>
        public NpcDiscSpace GetPreviousDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition - directionVector);
        }

        /// <summary>
        /// Get the next disc space in the direction of the given vector
        /// </summary>
        /// <returns></returns>
        public NpcDiscSpace GetNextDiscSpace(Vector2D currentPosition, Vector2D directionVector)
        {
            return GetDiscSpace(currentPosition + directionVector);
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


        #region Heuristic Scoring

        /// <summary>
        /// Retrieve the current heuristic score for the given disc color
        /// </summary>
        public int GetHeuristicScoreForGivenColor(DiscType color)
        {
            int score = 0;

            score += GetCornerSpacesScoreByColor(color);
            score += GetDiscCountScoreByColor(color);
            score += GetDangerSpacesScoreByColor(color);

            return score;
        }

        /// <summary>
        /// Get the disc count score for the specified color
        /// </summary>
        public int GetDiscCountScoreByColor(DiscType color)
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
        /// Get a score based on the amount of discs a color has on the corners of the board.
        /// These spaces are more valuable as they can never be flipped back
        /// Score delta: 2 / space
        /// </summary>
        public int GetCornerSpacesScoreByColor(DiscType color)
        {
            IList<IDiscSpace> cornerSpaces = new List<IDiscSpace>()
            {
                GetDiscSpace(0,0),
                GetDiscSpace(7,0),
                GetDiscSpace(0,7),
                GetDiscSpace(7,7)
            };

            return cornerSpaces
                .Where(space => space.DiscColor == color)
                .Count() * 2;
        }

        /// <summary>
        /// Get a score based on the amount of discs a color has on the danger spaces of the board.
        /// These spaces surround the corners and allow the opponent to take a corner space
        /// Score delta: -2 / space
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public int GetDangerSpacesScoreByColor(DiscType color)
        {
            IList<IDiscSpace> cornerSpaces = new List<IDiscSpace>()
            {
                // Spaces surrounding top left corner
                GetDiscSpace(0,1), GetDiscSpace(1,0), GetDiscSpace(1,1),

                // Spaces surrounding top right corner
                GetDiscSpace(6,0), GetDiscSpace(6,1), GetDiscSpace(7,1),

                // Spaces surrounding bottom left corner
                GetDiscSpace(0,6), GetDiscSpace(1,6), GetDiscSpace(1,7),

                // Spaces surrounding bottom right corner
                GetDiscSpace(6,6), GetDiscSpace(6,7), GetDiscSpace(7,6),
            };

            return cornerSpaces
                .Where(space => space.DiscColor == color)
                .Count() * -2;
        }

        #endregion

        #endregion

        #region Game logic

        /// <summary>
        /// Add containers for each space on the board & trigger the game setup
        /// </summary>
        public void BoardSetup()
        {
            for (int rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 8; columnIndex++)
                {
                    NpcDiscSpace discSpace = new NpcDiscSpace(columnIndex, rowIndex);

                    BoardSpaces.Add(discSpace);
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
            foreach (NpcDiscSpace discSpace in BoardSpaces)
            {
                discSpace.SetDisc(DiscType.Empty);
            }
        }

        /// <summary>
        /// Get all legal moves for a <see cref="DiscType"/>(color)
        /// </summary>
        /// <param name="CurrentTurnColor">The <see cref="DiscType"/>(color) to find legal moves for</param>
        /// <returns>A list of spaces representing legal moves</returns>
        public IList<Vector2D> GetLegalMoves(DiscType discColor)
        {
            var legalMoves = new List<Vector2D>();

            foreach (NpcDiscSpace initialSpace in
                BoardSpaces.Where(b => b.DiscColor == discColor).ToList())
            {
                for (int columnDirection = -1; columnDirection <= 1; columnDirection++)
                {
                    for (int rowDireciton = -1; rowDireciton <= 1; rowDireciton++)
                    {
                        // Skip directional vector <0,0>
                        if (columnDirection == 0 && rowDireciton == 0) continue;

                        Vector2D legalOrNullMove = GetLegalMoveForDirection(
                            initialSpace,
                            new Vector2D(columnDirection, rowDireciton));

                        // If it is a legal move
                        if (legalOrNullMove is not null)
                        {
                            // Add it to the legal moves
                            legalMoves.Add(legalOrNullMove);
                        }
                    }
                }
            }

            // Ensures there are no repeated legal moves
            legalMoves = legalMoves.Distinct(new Vector2DComparer()).ToList();

            return legalMoves;
        }

        /// <summary>
        /// Find if there is a legal move in the given direction
        /// </summary>
        /// <param name="initialSpace"></param>
        /// <param name="directionVector"></param>
        /// <returns>The <see cref="NpcDiscSpace"/> of a legal move if there is one, else return null</returns>
        private Vector2D GetLegalMoveForDirection(NpcDiscSpace initialSpace, Vector2D directionVector)
        {
            // Move two spaces in the given direction
            var currentPosition = new Vector2D(
                column: initialSpace.Column + directionVector.Column,
                row: initialSpace.Row + directionVector.Row);

            while (PositionIsOnBoard(currentPosition))
            {
                NpcDiscSpace currentSpace = GetDiscSpace(currentPosition);

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
        /// Removes ability to interact with previously legal moves
        /// </summary>
        private void DisableLegalMoves()
        {
            foreach (var legalMove in CurrentLegalMoves)
            {
                GetDiscSpace(legalMove).SetDisc(DiscType.Empty);
            }
        }

        /// <summary>
        /// Allows board spaces representing legal moves for the current turn's color to be interacted with
        /// </summary>
        public void EnableLegalMoves()
        {
            CurrentLegalMoves = GetLegalMoves(CurrentTurnColor);
        }

        /// <summary>
        /// Flip all discs of the opposite color between the given disc and 
        /// the next disc of that same color in every direction
        /// </summary>
        /// <param name="performedLegalMove">The legal move that caused pieces to be flanked</param>
        private void FlipDiscs(Vector2D performedLegalMove)
        {
            NpcDiscSpace legalMoveSpace = GetDiscSpace(performedLegalMove);
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

        /// <summary>
        /// Flip all discs in a given direction until a disc of the same color is reached
        /// </summary>
        private void FlipDiscsInDirection(NpcDiscSpace legalMoveSpace, Vector2D directionVector)
        {
            Vector2D currentPosition = new Vector2D(
                column: legalMoveSpace.Column + directionVector.Column,
                row: legalMoveSpace.Row + directionVector.Row);

            // Move in the given direction until you reach a piece of your same color
            while (PositionIsOnBoard(currentPosition))
            {
                IDiscSpace currentSpace = GetDiscSpace(currentPosition);

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
                    NpcDiscSpace currentSpace = GetDiscSpace(currentPosition);

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

        /// <summary>
        /// Flip the disc in a given disc space to the given color
        /// </summary>
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
        /// When a player clicks a space to place a disc into,
        /// </summary>
        public void PerformTurn(Vector2D performedLegalMove)
        {
            DisableLegalMoves();
            GetDiscSpace(performedLegalMove).SetDisc(CurrentTurnColor);
            // Update score
            if (CurrentTurnColor == DiscType.Black)
            {
                BlackScore++;
            }
            else
            {
                WhiteScore++;
            }

            FlipDiscs(CurrentLegalMoves.First(move => move.Equals(performedLegalMove)));
            SwitchTurns();
            EnableLegalMoves();
        }

        /// <summary>
        /// Switch the current turn to the opposite color
        /// </summary>
        private void SwitchTurns()
        {
            CurrentTurnColor = ControlDiscSpace.GetOppositeDiscColor(CurrentTurnColor);
        }

        #endregion
    }
}
