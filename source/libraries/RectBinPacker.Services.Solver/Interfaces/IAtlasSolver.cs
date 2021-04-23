using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Services.Solver.Interfaces
{
    public interface IAtlasSolver<T> where T : IItem
    {
        int Width { set; }

        int Height { set; }

        IList<T> Items { set; }
        IList<IValidator> Validators { set; }

        IAtlas<T> Solve();
       
        bool IsConfigured();
    }
}
