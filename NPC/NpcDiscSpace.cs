﻿using GameOfOthelloAssignment.Enums;
using GameOfOthelloAssignment.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfOthelloAssignment.NPC
{
    [DebuggerDisplay("Position: ({Column},{Row}), Disc: {DiscColor})}")]
    public class NpcDiscSpace
    {
        #region Properties

        public int Column { get; set; }

        public int Row { get; set; }

        public DiscType DiscColor { get; set; }

        #endregion


        public NpcDiscSpace() { }

        public NpcDiscSpace(int column, int row)
        {
            Column = column;
            Row = row;
            DiscColor = DiscType.Empty;
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
        public static implicit operator Vector2D(NpcDiscSpace discSpace)
        {
            return new Vector2D(discSpace.Column, discSpace.Row);
        }
    }
}