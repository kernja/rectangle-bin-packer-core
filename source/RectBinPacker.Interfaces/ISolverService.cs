using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface ISolverService
    {
        IAtlas Solve(int width, int height, IList<IItem> items);
    }
}
