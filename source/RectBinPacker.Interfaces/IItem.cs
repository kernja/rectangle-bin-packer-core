using System;
using System.Runtime.Serialization;

namespace RectBinPacker.Interfaces
{
    public interface IItem
    {
        public int Width { get; }
        public int Height { get; }

    }
}
