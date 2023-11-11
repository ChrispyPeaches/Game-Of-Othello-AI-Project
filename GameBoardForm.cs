﻿using GameOfOthelloAssignment.NPC;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public partial class GameBoardForm : Form
    {
        private GameMode gameMode;
        private DiscType player1Color;
        public bool DEBUG;

        public GameBoardForm(DiscType player1Color, GameMode gameMode)
        {
            this.gameMode = gameMode;
            this.player1Color = player1Color;
            InitializeComponent();
            othelloBoard.BoardSetup();
            othelloBoard.TurnFinished += OnTurnFinished;
            FormSetup();
        }

        private void FormSetup()
        {
            OnTurnFinished();
        }

        private void OnTurnFinished()
        {
            UpdateCurrentTurnMenu();
            UpdateScoreMenu();
            if (gameMode == GameMode.AI)
            {
                // Display trailing dots for "thinking"
            }

            if (othelloBoard.IsGameOver())
            {
                // Game over sequence
            }
        }

        private void UpdateCurrentTurnMenu()
        {
            pic_currentTurnMenu_piece.BackgroundImage = 
                FormDiscSpace.GetBackgroundImageByDiscType(othelloBoard.CurrentTurnColor);
            btn_CurrentTurnMenu_Detail.Text = othelloBoard.CurrentTurnColor.ToString();
        }

        private void UpdateScoreMenu()
        {
            btn_ScoreMenu_Black.Text = othelloBoard.BlackScore.ToString();
            btn_ScoreMenu_White.Text = othelloBoard.WhiteScore.ToString();
        }
    }
}
