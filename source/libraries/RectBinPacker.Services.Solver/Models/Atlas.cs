using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Services.Solver.Models
{
    public class Atlas : IAtlas
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        internal IList<ConfiguredItem> ConfiguredItems { get; set; }

        public IList<IConfiguredItem> GetConfiguredItems()
        {
            return (IList<IConfiguredItem>)ConfiguredItems;
        }

        internal int Area()
        {
            return Height * Width;
        }
    }
}
