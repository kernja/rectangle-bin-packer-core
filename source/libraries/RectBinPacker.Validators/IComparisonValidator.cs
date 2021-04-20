using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public interface IScaleValidator
    {
        ECompareType Comparison { get; }
        
        decimal Value { get; }
    }
}
