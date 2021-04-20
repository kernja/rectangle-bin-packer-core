using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Services.Solver.Interfaces
{
    internal interface IAtlasSolver
    {
        int Width { set; }

        int Height { set; }

        IList<IItem> Items { set; }
        IList<IValidator> Validators { set; }

        bool IsConfigured();

        IAtlas Solve();
    }
}
