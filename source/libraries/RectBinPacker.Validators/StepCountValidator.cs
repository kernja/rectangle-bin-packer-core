using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Validators
{
    public class StepCountValidator : ComparisonValidator
    {
        public override bool Validate<T>(IAtlas<T> atlas, out string parameterName, out string errorMessage)
        {
            // set our default string values
            errorMessage = null;
            parameterName = "StepCount";

            // validate 
            if (!base.Validate(atlas.StepCount, "StepCountValidator", out errorMessage))
                return false;
           
            // if we passed all of the checks, then we're good.
            return true;
        }
    }
}
