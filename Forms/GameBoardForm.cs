using GameOfOthelloAssignment.Controls;
using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using GameOfOthelloAssignment.NPC;
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
            InitializeComponent();
            this.gameMode = gameMode;
            this.player1Color = player1Color;
            OthelloBoardSetup();
            textBox_DebugMenu_SearchDepth.Text = searchDepth.ToString();
        }

        private void OthelloBoardSetup()
        {
            OnTurnFinished();
            SetupScoreMenu();
            othelloBoard.Player1DiscColor = player1Color;
            othelloBoard.gameMode = gameMode;
            othelloBoard.TurnFinished += OnTurnFinished;
            othelloBoard.GameOver += OnGameOver;
            othelloBoard.BoardSetup();
            if (gameMode == GameMode.AI && othelloBoard.CurrentTurnColor != player1Color)
            {
                PerformNpcTurn();
            }
        }

        private void OnTurnFinished()
        {
            UpdateCurrentTurnMenu();
            UpdateScoreMenu();

            if (gameMode == GameMode.AI && othelloBoard.CurrentTurnColor != player1Color)
            {
                PerformNpcTurn();
            }
        }

        #region Npc

        public void PerformNpcTurn()
        {
            DisplayNpcThinking(true);
            
            // Perform Minimax
            var clonedGameState = CloneHelper.CloneFromFormBoardToNPCBoard(othelloBoard);
            MiniMaxResult ParentBestResult = NPC.NPC.MiniMax(
                clonedGameState,
                searchDepth,
                othelloBoard.CurrentTurnColor);
            if (DEBUG)
            {
                NPC.NPC.PrintSequencesHelper(ParentBestResult);
            }
            // If there are any legal moves, play the found best one
            if (ParentBestResult.ExtremeResult.Position != null)
            {
                othelloBoard.PerformTurn(othelloBoard.GetDiscSpace(ParentBestResult.ExtremeResult.Position));
            }

            DisplayNpcThinking(false);
        }

        /// <summary>
        /// Displays or hides the "Thinking..." label for the Npc
        /// </summary>
        public void DisplayNpcThinking(bool shouldDisplay)
        {
            btn_AIThinking_Detail.Visible = shouldDisplay;
            Refresh();
        }

        #endregion

        /// <summary>
        /// Display the current turn's disc color
        /// </summary>
        private void UpdateCurrentTurnMenu()
        {
            pic_currentTurnMenu_piece.BackgroundImage =
                ControlDiscSpace.GetBackgroundImageByDiscType(othelloBoard.CurrentTurnColor);
            btn_CurrentTurnMenu_Detail.Text = othelloBoard.CurrentTurnColor.ToString();
        }

        #region Game Over Menu

        private void SetupGameOverMenu()
        {
            bool player1Wins = othelloBoard.GetCurrentlyWinningColor() == player1Color;

            switch (gameMode)
            {
                case GameMode.AI:
                    if (!player1Wins)
                    {
                        btn_GameOverMenu_Title.ForeColor = System.Drawing.Color.Red;
                        btn_GameOverMenu_Subtitle.Text = "You Lost";
                    }
                    else
                    {

                        btn_GameOverMenu_Subtitle.Text = "You Win!";
                    }
                    break;
                case GameMode.TwoPlayer:
                    btn_GameOverMenu_Subtitle.Text = (player1Wins) ? "Player 1 Wins" : "Player 2 Wins";
                    break;
            }
        }

        /// <summary>
        /// When the game is over, setup, then show the game over menu
        /// </summary>
        private void OnGameOver()
        {
            SetupGameOverMenu();
            panel_GameOverMenu_Container.Visible = true;
        }

        #endregion

        #region Score Menu

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

        #endregion

        #region Debug Menu

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

        #endregion
    }
}
