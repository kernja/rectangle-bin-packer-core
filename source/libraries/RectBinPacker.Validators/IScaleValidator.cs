﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public enum ECompareType
    {
        EQUAL,
        NOTEQUAL,
        LESSTHAN,
        LESSTHANEQUALTO,
        GREATERTHAN,
        GREATERTHANEQUALTO
    }

    public interface IScaleValidator
    {
        void Configure(ECompareType comparison, decimal value);
    }
}
