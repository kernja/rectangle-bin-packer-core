using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RectBinPacker.Services.Solver
{
    public class SolverService : ISolverService
    {
        private readonly IValidatorRegistration _validatorRegistration;

        public SolverService(IValidatorRegistration validatorRegistration)
        {
            _validatorRegistration = validatorRegistration;
        }

        public IAtlas Solve(int height, int width, IList<IItem> items, IList<IValidator> validators = null)
        {
            IList<IValidator> validatorsToUse = _validatorRegistration.GetValidators();
            if (validators != null)
                validatorsToUse = validators;

            var solver = new AtlasSolver() { Items = items, Validators = validators, Width = width, Height = height };
            return solver.Solve();
        }
    }
}
