using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface ISolverValidator
    {
        bool Validate(IList<IConfiguredItem> configuredItems, out string errorMessage);
    }
}
