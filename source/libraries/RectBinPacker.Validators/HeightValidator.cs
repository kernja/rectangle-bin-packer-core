﻿using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public class HeightValidator : ComparisonValidator
    {
        public override bool Validate(IAtlas atlas, out string parameterName, out string errorMessage)
        {
            // set our default string values
            errorMessage = null;
            parameterName = "Height";

            // get our items
            var configuredItems = atlas.GetConfiguredItems();
            
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
