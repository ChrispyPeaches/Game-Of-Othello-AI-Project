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
        /// <summary> Note: Zero based </summary>
        public int Column { get; set; }

        /// <summary> Note: Zero based </summary>
        public int Row { get; set; }

        /// <summary>
        /// The <see cref="Disc"/> occupying the space
        /// </summary>
        public Disc CurrentDisc { get; private set; }

        public DiscSpace(int columnIndex, int rowIndex) : base()
        {
            AutoSize = true;
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImage = Properties.Resources.black_piece;
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

            Enter += new System.EventHandler(Focus);
            Leave += new System.EventHandler(Unfocus);

            Column = columnIndex;
            Row = rowIndex;
        }

        /// <summary>
        /// Setter for assigning a <see cref="Disc"/> to a disc space
        /// </summary>
        /// <param name="disc">The <see cref="Disc"/> to place in </param>
        public void SetDisc(Disc disc)
        {
            if (disc != null)
            {
                switch (disc.Color)
                {
                    case DiscType.Black:
                        BackgroundImage= Properties.Resources.black_piece;
                        break;
                    case DiscType.White:
                        BackgroundImage = Properties.Resources.white_piece;
                        break;
                }

                disc.Column = Column;
                disc.Row = Row;
            }
            else
            {
                BackgroundImage = null;
            }

            CurrentDisc = disc;
        }

        public void Focus(object sender, EventArgs e)
        {
            if (CurrentDisc == null)
            {
                BackColor = Color.LightGoldenrodYellow;
                FlatAppearance.MouseDownBackColor = BackColor;
                FlatAppearance.MouseOverBackColor = BackColor;
            }
        }

        public void Unfocus(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = BackColor;
            FlatAppearance.MouseOverBackColor = BackColor;
        }
    }

    public class Disc
    {
        public Disc(DiscType color)
        {
            Color = color;
        }

        public DiscType Color { get; set; }

        public int Column { get; set; }
        public int Row { get; set; }
    }

    public enum DiscType
    {
        Black,
        White
    }
}
