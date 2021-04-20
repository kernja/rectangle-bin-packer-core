using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public class HeightValidator : ComparisonValidator
    {
        public override bool Validate(IList<IConfiguredItem> configuredItems, out string errorMessage)
        {
            // set our default error message, which is nothing.
            errorMessage = null;

            // iterate through each configured item
            foreach (var ci in configuredItems)
            {
                // get the scale of the configured item, and round it.
                var ciRoundedScale = Decimal.Round(ci.Height, ConstRoundTo);

                if (!base.Validate(ciRoundedScale, "HeightValidator", out errorMessage))
                    return false;
            }

            // if we passed all of the checks, then we're good.
            return true;
        }
    }
}
