using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    internal class DiscSpace : Button
    {
        /// <summary>
        /// Note: Zero based
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Note: Zero based
        /// </summary>
        public int Row { get; set; }

        public Disc currentDisc { get; private set; }

        public DiscSpace() : base()
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
        }

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
        }
    }

    internal class Disc
    {
        public DiscType Color { get; set; }

        public int Column { get; set; }
        public int Row { get; set; }
    }

    internal enum DiscType
    {
        Black,
        White
    }
}
