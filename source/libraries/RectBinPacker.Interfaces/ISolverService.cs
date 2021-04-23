using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface ISolverService
    {
        bool Solve<T>(int height, int width, IList<T> items, out IAtlas<T> atlasOutput, IList<IValidator> validators = null) where T: IItem;
    }
}
