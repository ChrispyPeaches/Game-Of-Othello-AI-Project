using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using GameOfOthelloAssignment.Properties;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfOthelloAssignment.Controls
{
    [DebuggerDisplay("Position: ({Column},{Row}), Disc: {DiscColor})}")]
    public class ControlDiscSpace : Button, IDiscSpace
    {
        #region Properties

        /// <summary> Note: Zero based </summary>
        public int Column { get; set; }

        /// <summary> Note: Zero based </summary>
        public int Row { get; set; }

        public DiscType DiscColor { get; set; }

        #endregion

        public ControlDiscSpace(int columnIndex, int rowIndex) : base()
        {
            AutoSize = true;
            BackColor = Color.Transparent;
            BackgroundImage = null;
            BackgroundImageLayout = ImageLayout.Zoom;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            ForeColor = Color.Transparent;
            Location = new Point(120, 60);
            Size = new Size(51, 49);
            TabIndex = 0;
            UseVisualStyleBackColor = false;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = FlatAppearance.MouseDownBackColor;
            Enabled = false;
            SetDisc(DiscType.Empty);

            Column = columnIndex;
            Row = rowIndex;
        }

        /// <summary>
        /// Set the space to hold a disc of a given color or no disc at all
        /// </summary>
        public void SetDisc(DiscType discColor)
        {
            DiscColor = discColor;
            BackgroundImage = GetBackgroundImageByDiscType(discColor);
        }

        public static Image GetBackgroundImageByDiscType(DiscType discColor)
        {
            switch (discColor)
            {
                case DiscType.Black:
                    return Resources.black_piece;
                case DiscType.White:
                    return Resources.white_piece;
                case DiscType.Empty:
                    return null;
                default:
                    return null;
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
            SetDisc(DiscType.Empty);
        }

        public static DiscType GetOppositeDiscColor(DiscType color)
        {
            switch (color)
            {
                case DiscType.Black:
                    return DiscType.White;
                case DiscType.White:
                    return DiscType.Black;
                default:
                    return DiscType.Empty;
            }
        }

        public bool HasOppositeDiscColor(DiscType color)
        {
            return DiscColor == GetOppositeDiscColor(color);
        }

        /// <summary>
        /// Implicit cast to Vector2D to represent a position on the board
        /// </summary>
        public static implicit operator Vector2D(ControlDiscSpace discSpace)
        {
            return new Vector2D(discSpace.Column, discSpace.Row);
        }
    }
}