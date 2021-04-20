﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IValidator
    {
        bool Validate(IAtlas atlas, out string parameterName, out string errorMessage);
    }
}
