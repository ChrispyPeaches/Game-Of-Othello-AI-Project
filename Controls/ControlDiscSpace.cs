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

        /// <summary>
        /// The column in which this is represented 
        /// </summary>
        public int Column { get; set; }

        /// <summary> 
        /// The row in which this is represented
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// The color occupying this
        /// </summary>
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

        /// <summary>
        /// Get the disc image associated with a given color
        /// </summary>
        /// <param name="discColor">the target disc's image</param>
        /// <returns></returns>
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

        /// <summary> Allow the space to be interacted with & update the space to signify a legal move </summary>
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

        /// <summary>
        /// Remove the user's ability to interact with a space
        /// </summary>
        public void DiableLegalMove()
        {
            Enabled = false;
            SetDisc(DiscType.Empty);
        }

        /// <summary>
        /// Get the opposite disc color to the one given
        /// </summary>
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

        /// <summary>
        /// Check if this disc space has the opposite color to the one given
        /// </summary>
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