using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IConfiguredItem<T> where T : IItem
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public decimal Scale { get; }
        public T OriginalItem { get; }

    }
}
