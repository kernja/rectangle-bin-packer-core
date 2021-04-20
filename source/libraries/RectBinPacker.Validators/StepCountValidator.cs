using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public class StepCountValidator : ComparisonValidator
    {
        public override bool Validate(IAtlas atlas, out string parameterName, out string errorMessage)
        {
            // set our default string values
            errorMessage = null;
            parameterName = "StepCount";

            // validate 
            if (!base.Validate(atlas.StepCount, "WidthValidator", out errorMessage))
                return false;
           
            // if we passed all of the checks, then we're good.
            return true;
        }
    }
}
