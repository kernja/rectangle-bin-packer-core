using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IValidator
    {
        bool Validate<T>(IAtlas<T> atlas, out string parameterName, out string errorMessage) where T : IItem;
    }
}
