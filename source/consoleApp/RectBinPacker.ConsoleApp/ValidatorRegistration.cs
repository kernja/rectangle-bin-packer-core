using RectBinPacker.Interfaces;
using RectBinPacker.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.ConsoleApp
{
    public class ValidatorRegistration : IValidatorRegistration
    {
        public IList<IValidator> GetValidators()
        {
            return new List<IValidator>
            {
                new ScaleValidator { Comparison  = ECompareType.EQUAL, Value = 1 },
                new WidthValidator { Comparison  = ECompareType.GREATERTHAN, Value = 0 },
                new HeightValidator { Comparison  = ECompareType.GREATERTHAN, Value = 0 },
                new ItemCountValidator { Comparison  = ECompareType.GREATERTHANEQUALTO, Value = 1 },
            };
        }
    }
}
