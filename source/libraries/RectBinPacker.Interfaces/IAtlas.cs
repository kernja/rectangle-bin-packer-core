using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IAtlas<T> where T : IItem
    {
        public int Width { get; }
        public int Height { get; }
        public int StepCount { get; }
        public IList<IConfiguredItem<T>> GetConfiguredItems();
    }
}
