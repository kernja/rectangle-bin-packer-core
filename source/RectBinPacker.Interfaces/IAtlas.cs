using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IAtlas
    {
        public int Width { get; }
        public int Height { get; }
        public IList<IConfiguredItem> GetConfiguredItems();
    }
}
