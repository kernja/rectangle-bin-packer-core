using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RectBinPacker.Services.Solver
{
    public class SolverService : ISolverService
    {
        private readonly IDefaultValidators _validatorRegistration;

        public SolverService(IDefaultValidators validatorRegistration)
        {
            _validatorRegistration = validatorRegistration;
        }

        public IAtlas Solve(int height, int width, IList<IItem> items, IList<IValidator> validators = null)
        {
            // generate the validators we should use
            IList<IValidator> validatorsToUse = _validatorRegistration.GetValidators();
            if (validators != null)
                validatorsToUse = validators;

            // run the solver
            var solver = new AtlasSolver() { Items = items, Validators = validatorsToUse, Width = width, Height = height };
            return solver.Solve();
        }
    }
}
