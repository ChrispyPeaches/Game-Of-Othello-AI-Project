using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public partial class GameBoardForm : Form
    {
        public GameBoardForm()
        {
            InitializeComponent();
            othelloBoard.BoardSetup();
            othelloBoard.TurnFinished += OnTurnFinished;
            FormSetup();
        }

        public void FormSetup()
        {
            OnTurnFinished();
        }

        public void OnTurnFinished()
        {
            UpdateCurrentTurnMenu();
            UpdateScoreMenu();
        }

        public void UpdateCurrentTurnMenu()
        {
            pic_currentTurnMenu_piece.BackgroundImage = 
                DiscSpace.GetBackgroundImageByDiscType(othelloBoard.CurrentTurnColor);
            btn_CurrentTurnMenu_Detail.Text = othelloBoard.CurrentTurnColor.ToString();
        }

        public void UpdateScoreMenu()
        {
            btn_ScoreMenu_Black.Text = othelloBoard.BlackScore.ToString();
            btn_ScoreMenu_White.Text = othelloBoard.WhiteScore.ToString();
        }
    }
}
