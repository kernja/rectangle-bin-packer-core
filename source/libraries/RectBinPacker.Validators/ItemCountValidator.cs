using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public class ItemCountValidator : ComparisonValidator
    {
        public override bool Validate(IList<IConfiguredItem> configuredItems, out string errorMessage)
        {
            // set our default error message, which is nothing.
            errorMessage = null;

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
