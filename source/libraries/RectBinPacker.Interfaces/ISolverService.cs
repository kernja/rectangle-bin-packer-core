using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface ISolverService
    {
        ISolver CreateSolver();

        ISolver CreateSolver(IList<IItem> items, IList<ISolverValidator> validators);
    }
}
