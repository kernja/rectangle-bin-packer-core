using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;

namespace RectBinPacker.Validators
{
    public abstract class ComparisonValidator : IValidator, IComparisonValidator
    {
        protected const int ConstRoundTo = 2;

        protected decimal _comparisonValue;
        public decimal Value
        {
            get
            {
                return _comparisonValue;
            }
            set
            {
                _comparisonValue = Decimal.Round(value, ConstRoundTo);
            }
        }
        public ECompareType Comparison { get; set; } = ECompareType.EQUAL;

        public abstract bool Validate(IAtlas atlas, out string parameterName, out string errorMessage);

        protected bool Validate(decimal ciRoundedValue, string validatorName, out string errorMessage)
        {
            // set our default error message, which is nothing.
            errorMessage = null;

            // now do our comparison
            switch (Comparison)
            {
                case ECompareType.EQUAL:
                    if (!(ciRoundedValue == _comparisonValue))
                    {
                        errorMessage = string.Format("{0}.Validate failed. {1} is not equal to {2}", validatorName, ciRoundedValue.ToString(), _comparisonValue.ToString());
                        return false;
                    }
                    break;
                case ECompareType.GREATERTHAN:
                    if (!(ciRoundedValue > _comparisonValue))
                    {
                        errorMessage = string.Format("{0}.Validate failed. {1} is not greater than {2}", validatorName, ciRoundedValue.ToString(), _comparisonValue.ToString());
                        return false;
                    }
                    break;
                case ECompareType.GREATERTHANEQUALTO:
                    if (!(ciRoundedValue >= _comparisonValue))
                    {
                        errorMessage = string.Format("{0}.Validate failed. {1} is not greater than or equal to {2}", validatorName, ciRoundedValue.ToString(), _comparisonValue.ToString());
                        return false;
                    }
                    break;
                case ECompareType.LESSTHAN:
                    if (!(ciRoundedValue < _comparisonValue))
                    {
                        errorMessage = string.Format("{0}.Validate failed. {1} is not less than {2}", validatorName, ciRoundedValue.ToString(), _comparisonValue.ToString());
                        return false;
                    }
                    break;
                case ECompareType.LESSTHANEQUALTO:
                    if (!(ciRoundedValue <= _comparisonValue))
                    {
                        errorMessage = string.Format("{0}.Validate failed. {1} is not less than or equal to {2}", validatorName, ciRoundedValue.ToString(), _comparisonValue.ToString());
                        return false;
                    }
                    break;
                case ECompareType.NOTEQUAL:
                    if (!(ciRoundedValue != _comparisonValue))
                    {
                        errorMessage = string.Format("{0}.Validate failed. {1} is equal to {2}", validatorName, ciRoundedValue.ToString(), _comparisonValue.ToString());
                        return false;
                    }
                    break;

            }

            // if we passed all of the checks, then we're good.
            return true;
        }
    }
}
