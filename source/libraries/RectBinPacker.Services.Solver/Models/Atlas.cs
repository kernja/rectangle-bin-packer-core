using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RectBinPacker.Services.Solver.Models
{
    public sealed class Atlas<T> : IAtlas<T> where T: IItem
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        public int StepCount { get; internal set; }
        internal IList<ConfiguredItem<T>> ConfiguredItems { get; set; }

        public IList<IConfiguredItem<T>> GetConfiguredItems()
        {
            return ConfiguredItems.Select(ci => (IConfiguredItem<T>)ci).ToList();
        }

        internal int Area()
        {
            return Height * Width;
        }
    }
}
