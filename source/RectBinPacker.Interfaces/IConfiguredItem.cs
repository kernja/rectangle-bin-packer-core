using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IConfiguredItem
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public float Scale { get; }
        public IItem OriginalItem { get; }

        /*
        public bool Placed { get; set; }
        public int GetArea();
        public bool OccupiesLocation(int X, int Y);*/

    }
}
