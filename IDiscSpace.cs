using GameOfOthelloAssignment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
