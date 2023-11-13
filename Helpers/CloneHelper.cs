using GameOfOthelloAssignment.Controls;
using GameOfOthelloAssignment.NPC;

namespace GameOfOthelloAssignment.Helpers
{
    public class CloneHelper
    {
        /// <summary>
        /// Create an Npc board type clone of the game state from the Control board type 
        /// </summary>
        public static NpcOthelloBoard CloneFromFormBoardToNPCBoard(ControlOthelloBoard board)
        {
            NpcOthelloBoard npcClone = new NpcOthelloBoard()
            {
                BlackScore = board.BlackScore,
                WhiteScore = board.WhiteScore,
                CurrentTurnColor = board.CurrentTurnColor,
            };
            foreach (ControlDiscSpace control in board.Controls)
            {
                npcClone.BoardSpaces.Add(new NpcDiscSpace()
                {
                    Column = control.Column,
                    Row = control.Row,
                    DiscColor = control.DiscColor
                });
            }

            npcClone.EnableLegalMoves();
            return npcClone;
        }

        /// <summary>
        /// Create a form board type clone of the game state from the Npc board type 
        /// </summary>
        public static void CloneFromNPCBoardToFormBoard(NpcOthelloBoard npcBoard, ControlOthelloBoard formBoard)
        {
            formBoard.WhiteScore = npcBoard.WhiteScore;
            formBoard.BlackScore = npcBoard.BlackScore;
            foreach (NpcDiscSpace discSpace in npcBoard.BoardSpaces)
            {
                formBoard.GetDiscSpace(discSpace)
                    .SetDisc(discSpace.DiscColor);
            }
        }

        /// <summary>
        /// Create an Npc board type clone of the game state from the Npc board type 
        /// </summary>
        public static NpcOthelloBoard CloneFromNPCBoardToNPCBoard(NpcOthelloBoard sourceBoard)
        {
            NpcOthelloBoard cloneBoard = new NpcOthelloBoard()
            {
                BlackScore = sourceBoard.BlackScore,
                WhiteScore = sourceBoard.WhiteScore,
                CurrentTurnColor = sourceBoard.CurrentTurnColor,
            };
            foreach (NpcDiscSpace sourceDiscSpace in sourceBoard.BoardSpaces)
            {
                cloneBoard.BoardSpaces.Add(new NpcDiscSpace()
                {
                    Column = sourceDiscSpace.Column,
                    Row = sourceDiscSpace.Row,
                    DiscColor = sourceDiscSpace.DiscColor
                });
            }

            cloneBoard.EnableLegalMoves();
            return cloneBoard;
        }
    }
}
