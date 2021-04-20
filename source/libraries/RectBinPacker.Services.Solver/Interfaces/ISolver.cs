using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Services.Solver.Interfaces
{
    internal interface ISolver
    {
        void Configure(IList<IItem> items, IList<IValidator> validators);
        bool IsConfigured();

        IAtlas Solve();
    }
}
