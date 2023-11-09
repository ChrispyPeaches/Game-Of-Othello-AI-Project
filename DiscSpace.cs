using GameOfOthelloAssignment.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    [DebuggerDisplay("Position: ({Column},{Row}), Disc: {((CurrentDisc != null) ? CurrentDisc.Color.ToString() : \"None\")}")]
    public class DiscSpace : Button
    {
        #region Properties

        /// <summary> Note: Zero based </summary>
        public int Column { get; set; }

        /// <summary> Note: Zero based </summary>
        public int Row { get; set; }

        public DiscType SpaceColor { get; set; }

        #endregion

        public DiscSpace(int columnIndex, int rowIndex) : base()
        {
            AutoSize = true;
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImage = null;
            BackgroundImageLayout = ImageLayout.Zoom;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            ForeColor = System.Drawing.Color.Transparent;
            Location = new System.Drawing.Point(120, 60);
            Size = new System.Drawing.Size(51, 49);
            TabIndex = 0;
            UseVisualStyleBackColor = false;
            FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            FlatAppearance.MouseOverBackColor = FlatAppearance.MouseDownBackColor;
            Enabled = false;

            Column = columnIndex;
            Row = rowIndex;
        }

        /// <summary>
        /// Set the space to hold a disc of a given color or no disc at all
        /// </summary>
        /// <param name="discColor"></param>
        public void SetDisc(DiscType discColor)
        {
            switch (discColor)
            {
                case DiscType.Black:
                    BackgroundImage= Resources.black_piece;
                    break;
                case DiscType.White:
                    BackgroundImage = Resources.white_piece;
                    break;
                case DiscType.Empty:
                    BackgroundImage = null;
                    break;
            }
        }

        /// <summary> Allow the space to be interacted with </summary>
        /// <param name="color"> The color to set the legal move to </param>
        public void SetAsLegalMove(DiscType color)
        {
            Enabled = true;
            switch (color)
            {
                case DiscType.Black:
                    BackgroundImage = Resources.black_legalMove;
                    break;
                case DiscType.White:
                    BackgroundImage = Resources.white_legalMove;
                    break;
            }
        }

        /// <summary> Remove the ability to interact with a space </summary>
        public void DiableLegalMove()
        {
            Enabled = false;
            BackgroundImage = null;
        }

        public bool HasOppositeDiscColor(DiscType color)
        {
            switch (color)
            {
                case DiscType.Black:
                    return SpaceColor == DiscType.Black;
                case DiscType.White:
                    return SpaceColor == DiscType.White;
                case DiscType.Empty:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Implicit cast to Vector2D to represent a position on the board
        /// </summary>
        public static implicit operator Vector2D(DiscSpace discSpace)
        {
            return new Vector2D(discSpace.Column, discSpace.Row);
        }
    }

    public enum DiscType
    {
        Black,
        White,
        Empty
    }
}
