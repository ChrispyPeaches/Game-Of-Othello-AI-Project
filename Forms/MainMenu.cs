using GameOfOthelloAssignment.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public partial class MainMenu : Form
    {
        DiscType Player1DiscColor;

        public MainMenu()
        {
            InitializeComponent();
            Player1DiscColor = DiscType.Black;
        }

        private void btn_2Player_Click(object sender, EventArgs e)
        {
            using (var gameBoard = new GameBoardForm(Player1DiscColor, GameMode.TwoPlayer))
            {
                gameBoard.ShowDialog();
            }
        }

        private void btn_AI_Click(object sender, EventArgs e)
        {
            using (var gameBoard = new GameBoardForm(Player1DiscColor, GameMode.AI))
            {
                gameBoard.ShowDialog();
            }
        }

        private void btn_ChooseBlack(object sender, EventArgs e)
        {
            btn_ChooseColorMenu_Black.BackColor = SystemColors.ControlDark;
            btn_ChooseColorMenu_White.BackColor = SystemColors.ControlLight;
            Player1DiscColor = DiscType.Black;
        }

        private void btn_ChooseWhite(object sender, EventArgs e)
        {
            btn_ChooseColorMenu_White.BackColor = SystemColors.ControlDark;
            btn_ChooseColorMenu_Black.BackColor = SystemColors.ControlLight;
            Player1DiscColor = DiscType.White;

        }
    }
}
