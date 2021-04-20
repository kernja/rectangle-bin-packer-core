using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IValidator
    {
        bool Validate(IList<IConfiguredItem> configuredItems, out string errorMessage);
    }
}
