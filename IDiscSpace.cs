using GameOfOthelloAssignment.Enums;

namespace GameOfOthelloAssignment
{
    /// <summary>
    /// Represents a board space in which a disc can be placed
    /// </summary>
    public interface IDiscSpace
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

        /// <summary>
        /// Check if this disc space has the opposite color to the one given
        /// </summary>
        public bool HasOppositeDiscColor(DiscType color);
    }
}
