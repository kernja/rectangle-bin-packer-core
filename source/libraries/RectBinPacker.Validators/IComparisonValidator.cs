using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public interface IComparisonValidator
    {
        ECompareType Comparison { get; }
        
        decimal Value { get; }
    }
}
