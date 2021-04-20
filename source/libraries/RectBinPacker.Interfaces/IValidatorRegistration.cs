using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.Interfaces
{
    public interface IValidatorRegistration
    {
        IList<IValidator> GetValidators();
    }
}
