using GameOfOthelloAssignment.Controls;
using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public partial class GameBoardForm : Form
    {
        private GameMode gameMode;
        private DiscType player1Color;
        public bool DEBUG;
        public int searchDepth = 2;

        public GameBoardForm(DiscType player1Color, GameMode gameMode)
        {
            this.gameMode = gameMode;
            this.player1Color = player1Color;
            InitializeComponent();
            FormSetup();
        }

        private void FormSetup()
        {
            OnTurnFinished();
            SetupScoreMenu();
            othelloBoard.BoardSetup();
            othelloBoard.Player1DiscColor = player1Color;
            othelloBoard.gameMode = gameMode;
            othelloBoard.TurnFinished += OnTurnFinished;
            othelloBoard.GameOver += OnGameOver;
        }

        private void OnTurnFinished()
        {
            UpdateCurrentTurnMenu();
            UpdateScoreMenu();
            if (gameMode == GameMode.AI && othelloBoard.CurrentTurnColor != player1Color)
            {
                // Display trailing dots for "thinking"
                btn_AIThinking_Detail.Visible = true;
                Refresh();
                if (othelloBoard.CurrentTurnColor != player1Color)
                {
                    var npcBoard = CloneHelper.CloneFromFormBoardToNPCBoard(othelloBoard);
                    Vector2D bestMove = NPC.NPC.MiniMaxHelper(npcBoard, searchDepth, othelloBoard.CurrentTurnColor);
                    if (bestMove != null)
                    {
                        othelloBoard.PerformTurn(othelloBoard.GetDiscSpace(bestMove));
                    }
                }

                btn_AIThinking_Detail.Visible = false;
                Refresh();
            }
        }

        /// <summary>
        /// When the game is over, show the game over menu
        /// </summary>
        private void OnGameOver()
        {
            panel_GameOverMenu_Container.Visible = true;
        }

        /// <summary>
        /// Display the current turn's disc color
        /// </summary>
        private void UpdateCurrentTurnMenu()
        {
            pic_currentTurnMenu_piece.BackgroundImage = 
                DiscSpace.GetBackgroundImageByDiscType(othelloBoard.CurrentTurnColor);
            btn_CurrentTurnMenu_Detail.Text = othelloBoard.CurrentTurnColor.ToString();
        }

        /// <summary>
        /// Displaye player names in the score menu
        /// </summary>
        private void SetupScoreMenu()
        {
            string player1Text = "Player 1";
            string player2Text = 
                (gameMode == GameMode.TwoPlayer) ?
                    "Player 2"
                    : "AI";

            switch (player1Color)
            {
                case DiscType.Black:
                    btn_ScoreMenu_PlayerBlack_Label.Text = player1Text;
                    btn_ScoreMenu_PlayerWhite_Label.Text = player2Text;
                    break;
                case DiscType.White:
                    btn_ScoreMenu_PlayerBlack_Label.Text = player2Text;
                    btn_ScoreMenu_PlayerWhite_Label.Text = player1Text;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays current board score
        /// </summary>
        private void UpdateScoreMenu()
        {
            btn_ScoreMenu_Black.Text = othelloBoard.BlackScore.ToString();
            btn_ScoreMenu_White.Text = othelloBoard.WhiteScore.ToString();
        }

        /// <summary>
        /// If the value enterend into the search depth box is NOT a valid integer,
        /// prompt the user to change it
        /// </summary>
        private void textBox_DebugMenu_SearchDepth_ChangeValue(object sender, System.EventArgs e)
        {
            if (!int.TryParse(textBox_DebugMenu_SearchDepth.Text, out searchDepth))
            {
                textBox_DebugMenu_SearchDepth.Clear();
            }
        }

        /// <summary>
        /// Enable or Disable DEBUG mode depending on if the Enable Debug checkbox is checked
        /// </summary>
        private void checkBox_DebugMenu_EnableDebug_CheckedChanged(object sender, System.EventArgs e)
        {
            DEBUG = checkBox_DebugMenu_EnableDebug.Checked;
        }
    }
}
