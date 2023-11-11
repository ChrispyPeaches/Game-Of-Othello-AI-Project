using GameOfOthelloAssignment.NPC;
using GameOfOthelloAssignment.Properties;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public interface IDiscSpace
    {
        #region Properties

        /// <summary> Note: Zero based </summary>
        public int Column { get; set; }

        /// <summary> Note: Zero based </summary>
        public int Row { get; set; }

        public DiscType DiscColor { get; set; }

        #endregion

        public bool HasOppositeDiscColor(DiscType color);
    }

    [DebuggerDisplay("Position: ({Column},{Row}), Disc: {SpaceColor})}")]
    public class NPCDiscSpace
    {
        #region Properties

        public int Column { get; set; }

        public int Row { get; set; }

        public DiscType DiscColor { get; set; }

        #endregion

        public bool HasOppositeDiscColor(DiscType color)
        {
            switch (color)
            {
                case DiscType.Black:
                    return DiscColor == DiscType.White;
                case DiscType.White:
                    return DiscColor == DiscType.Black;
                case DiscType.Empty:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Implicit cast to Vector2D to represent a position on the board
        /// </summary>
        public static implicit operator Vector2D(NPCDiscSpace discSpace)
        {
            return new Vector2D(discSpace.Column, discSpace.Row);
        }
    }


    [DebuggerDisplay("Position: ({Column},{Row}), Disc: {SpaceColor})}")]
    public class FormDiscSpace : Button
    {
        #region Properties

        /// <summary> Note: Zero based </summary>
        public int Column { get; set; }

        /// <summary> Note: Zero based </summary>
        public int Row { get; set; }

        public DiscType DiscColor { get; set; }

        #endregion

        public FormDiscSpace(int columnIndex, int rowIndex) : base()
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
            DiscColor = DiscType.Empty;

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
            DiscColor = DiscType.Empty;
            BackgroundImage = null;
        }

        public bool HasOppositeDiscColor(DiscType color)
        {
            switch (color)
            {
                case DiscType.Black:
                    return DiscColor == DiscType.White;
                case DiscType.White:
                    return DiscColor == DiscType.Black;
                case DiscType.Empty:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Implicit cast to Vector2D to represent a position on the board
        /// </summary>
        public static implicit operator Vector2D(FormDiscSpace discSpace)
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
