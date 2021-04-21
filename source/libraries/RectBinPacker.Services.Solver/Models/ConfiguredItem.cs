using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Services.Solver.Models
{
    internal class ConfiguredItem<T> : IConfiguredItem<T> where T : IItem
    {

        #region Interface-defined properties
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public int Width
        {
            get
            {
                return (int)((decimal)OriginalItem.Width * Scale);
            }
        }
        public int Height
        {
            get
            {
                return (int)((decimal)OriginalItem.Height * Scale);
            }
        }
        public decimal Scale { get; internal set; }
        public T OriginalItem { get; internal set; }
        #endregion

        #region internal properties
        internal bool Placed { get; set; }
        #endregion

        /// <summary>
        /// Mulitplies this object's width, height, and scale together.
        /// </summary>
        /// <returns>Area that this object occupies.</returns>
        internal int Area()
        {
            return Height * Width;
        }

        /// <summary>
        /// Determines if this object occupies the coordinates at X,Y.
        /// </summary>
        /// <returns>True if this item occupies the space, false if not.</returns>
        internal bool OccupiesSpace(int X, int Y)
        {
            // If we're not placed, we cannot occupy space.
            if (Placed == false)
                return false;

            // Do bounds checking
            // Set up our variables
            int x1 = this.X, y1 = this.Y;
            int x2 = this.X + Width - 1;
            int y2 = this.Y + Height - 1;

            // Now do the test
            if ((X >= x1 && Y >= y1) && (X <= x2 && Y <=y2))
                return true;

            // the test failed, return false
            return false;
        }
    }
}
