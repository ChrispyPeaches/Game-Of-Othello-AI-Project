using System;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    /// <summary>
    /// Name:           Chris Perry
    /// Student Id:     10327025
    /// Date:           11/12/23
    /// Assignment#:    3
    /// Description:    An impelementation of the Game of Othello playable with 2 players or with 1 player against an AI.
    ///                 The AI uses the Min-Max algorithm to determine the next move to play with alpha-beta pruning
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
