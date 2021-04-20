using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface ISolverService
    {
        bool IsConfigured();
        IAtlas Solve(IList<IItem> items, IList<IValidator> validators);
    }
}
