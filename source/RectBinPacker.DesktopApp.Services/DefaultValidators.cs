﻿using RectBinPacker.Interfaces;
using RectBinPacker.Validators;
using System.Collections.Generic;

namespace RectBinPacker.DesktopApp.Services
{
    public class DefaultValidators : IDefaultValidators
    {
        public IList<IValidator> GetValidators()
        {
            return new List<IValidator>
            {
                new ItemScaleValidator { Comparison  = ECompareType.GREATERTHAN, Value = 0 },
                new ItemWidthValidator { Comparison  = ECompareType.GREATERTHAN, Value = 0 },
                new ItemHeightValidator { Comparison  = ECompareType.GREATERTHAN, Value = 0 },
                new ItemCountValidator { Comparison  = ECompareType.GREATERTHANEQUALTO, Value = 1 },
                new StepCountValidator { Comparison  = ECompareType.LESSTHANEQUALTO, Value = 1 },
            };
        }
    }
}
