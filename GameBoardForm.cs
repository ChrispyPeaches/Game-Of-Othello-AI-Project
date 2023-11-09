using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public partial class GameBoardForm : Form
    {
        IList<Vector2D> currentLegalMoves;
        DiscType currentTurnColor;

        public GameBoardForm()
        {
            InitializeComponent();

            // Add containers for each space on the board
            for (int rowIndex = 0; rowIndex < othelloBoard1.RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < othelloBoard1.ColumnCount; columnIndex++)
                {
                    DiscSpace discSpace = new DiscSpace(columnIndex, rowIndex);
                    discSpace.Click += PerformTurn;

                    othelloBoard1.Controls.Add(discSpace, columnIndex, rowIndex);
                }
            }

            GameSetup();
        }

        /// <summary> Clear the game board, add the starting discs to the game, and show legal moves. </summary>
        public void GameSetup()
        {
            ClearGameBoard();

            othelloBoard1.GetDiscSpace(3, 3).SetDisc(new Disc(DiscType.White));
            othelloBoard1.GetDiscSpace(4, 3).SetDisc(new Disc(DiscType.Black));
            othelloBoard1.GetDiscSpace(3, 4).SetDisc(new Disc(DiscType.Black));
            othelloBoard1.GetDiscSpace(4, 4).SetDisc(new Disc(DiscType.White));
            othelloBoard1.BlackScore = 2;
            othelloBoard1.WhiteScore = 2;

            currentTurnColor = DiscType.Black;
            EnableLegalMoves();
        }

        /// <summary>
        /// Clear all spaces on the board
        /// </summary>
        public void ClearGameBoard()
        {
            foreach (DiscSpace discSpace in othelloBoard1.Controls)
            {
                discSpace.SetDisc(null);
            }
        }

        /// <summary>
        /// When a player clicks a space to place a disc into,
        /// </summary>
        private void PerformTurn(object sender, EventArgs eventArgs)
        {
            DiscSpace clickedSpace = (DiscSpace) sender;
            DisableLegalMoves();
            othelloBoard1.GetDiscSpace(clickedSpace).SetDisc(new Disc(currentTurnColor));

            SwitchTurns();

                return;
        }

        /// <summary>
        /// Removes ability to interact with previously legal moves
        /// </summary>
        public void DisableLegalMoves()
        {
            foreach (var move in currentLegalMoves)
            {
                othelloBoard1.GetDiscSpace(move.Column, move.Row).DiableLegalMove();
            }
        }

        /// <summary>
        /// Allows board spaces representing legal moves for the current turn's color to be interacted with
        /// </summary>
        public void EnableLegalMoves()
        {
            currentLegalMoves = othelloBoard1.GetLegalMoves(currentTurnColor);
            foreach (var move in currentLegalMoves)
            {
                othelloBoard1.GetDiscSpace(move.Column, move.Row).SetAsLegalMove(currentTurnColor);
            }
        }

        public void SwitchTurns()
        {
            switch (currentTurnColor)
            {
                case DiscType.Black:
                    currentTurnColor = DiscType.White; break;
                case DiscType.White:
                    currentTurnColor = DiscType.Black; break;
            }
            EnableLegalMoves();
        }

    }
}
