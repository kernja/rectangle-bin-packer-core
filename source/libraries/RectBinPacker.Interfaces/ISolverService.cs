using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface ISolverService
    {
        IAtlas Solve(int height, int width, IList<IItem> items, IList<IValidator> validators = null);
    }
}
