using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;

namespace RectBinPacker.Validators
{
    public class ScaleValidator : ISolverValidator, IScaleValidator
    {
        private ECompareType _comparison = ECompareType.EQUAL;
        private decimal _comparisonValue = 1;
        const int ConstRoundTo = 2;

        public void Configure(ECompareType comparison, decimal value)
        {
            _comparison = comparison;
            _comparisonValue = Decimal.Round(value, ConstRoundTo);
        }

        public bool Validate(IList<IConfiguredItem> configuredItems, out string errorMessage)
        {
            // set our default error message, which is nothing.
            errorMessage = null;

            // iterate through each configured item
            foreach (var ci in configuredItems)
            {
                // get the scale of the configured item, and round it.
                var ciRoundedScale = Decimal.Round(ci.Scale, ConstRoundTo);

                // now do our comparison
                switch (_comparison)
                {
                    case ECompareType.EQUAL:
                        if (ciRoundedScale != _comparisonValue)
                        {
                            errorMessage = string.Format("ScaleValidator.Validate failed. {0} is not equal to {1}", ciRoundedScale.ToString(), _comparisonValue.ToString());
                            return false;
                        }
                        break;
                    case ECompareType.GREATERTHAN:
                        if (ciRoundedScale <= _comparisonValue)
                        {
                            errorMessage = string.Format("ScaleValidator.Validate failed. {0} is not greater than {1}", ciRoundedScale.ToString(), _comparisonValue.ToString());
                            return false;
                        }
                        break;
                    case ECompareType.GREATERTHANEQUALTO:
                        if (ciRoundedScale < _comparisonValue)
                        {
                            errorMessage = string.Format("ScaleValidator.Validate failed. {0} is not greater than or equal to {1}", ciRoundedScale.ToString(), _comparisonValue.ToString());
                            return false;
                        }
                        break;
                    case ECompareType.LESSTHAN:
                        if (ciRoundedScale >= _comparisonValue)
                        {
                            errorMessage = string.Format("ScaleValidator.Validate failed. {0} is not less than {1}", ciRoundedScale.ToString(), _comparisonValue.ToString());
                            return false;
                        }
                        break;
                    case ECompareType.LESSTHANEQUALTO:
                        if (ciRoundedScale > _comparisonValue)
                        {
                            errorMessage = string.Format("ScaleValidator.Validate failed. {0} is not less than or equal to {1}", ciRoundedScale.ToString(), _comparisonValue.ToString());
                            return false;
                        }
                        break;
                    case ECompareType.NOTEQUAL:
                        if (ciRoundedScale == _comparisonValue)
                        {
                            errorMessage = string.Format("ScaleValidator.Validate failed. {0} is equal to {1}", ciRoundedScale.ToString(), _comparisonValue.ToString());
                            return false;
                        }
                        break;

                }
            }

            // if we passed all of the checks, then we're good.
            return true;
        }
    }
}
