using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public class ItemCountValidator : ComparisonValidator
    {
        public override bool Validate(IAtlas atlas, out string parameterName, out string errorMessage)
        {
            // set our default string values
            errorMessage = null;
            parameterName = "Count";

            // get our items
            var configuredItems = atlas.GetConfiguredItems();

            // do a null error test
            if (configuredItems == null)
            {
                errorMessage = "ItemCountValidator.Validate failed. Configured item list was null.";
                return false;
            }

            if (!base.Validate(configuredItems.Count, "ItemCountValidator", out errorMessage))
                return false;

            // if we passed all of the checks, then we're good.
            return true;
        }
    }
}
