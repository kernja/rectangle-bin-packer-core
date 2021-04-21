using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface ISolverService
    {
        IAtlas<T> Solve<T>(int height, int width, IList<T> items, IList<IValidator> validators = null) where T: IItem;
    }
}
