using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;

namespace RectBinPacker.Validators
{
    public class ScaleValidator : ComparisonValidator
    {
        public override bool Validate(IAtlas atlas, out string parameterName, out string errorMessage)
        {
            // set our default string values
            errorMessage = null;
            parameterName = "Scale";

            // get our items
            var configuredItems = atlas.GetConfiguredItems();

            // iterate through each configured item
            foreach (var ci in configuredItems)
            {
                // get the scale of the configured item, and round it.
                var ciRoundedScale = Decimal.Round(ci.Scale, ConstRoundTo);

                if (!base.Validate(ciRoundedScale, "ScaleValidator", out errorMessage))
                    return false;
            }

            // if we passed all of the checks, then we're good.
            return true;
        }
    }
}
