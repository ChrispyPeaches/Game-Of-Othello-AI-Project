using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public class OthelloBoard : TableLayoutPanel
    {
        /// <summary>
        /// Note: 0-based
        /// </summary>
        public DiscSpace GetDiscSpace(int row, int column)
        {
            return (DiscSpace) this.GetControlFromPosition(column, row);
        }
    }
}
