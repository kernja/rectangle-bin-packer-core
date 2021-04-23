using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace RectBinPacker.Services.Solver
{
    public sealed class SolverService : ISolverService
    {
        private readonly IDefaultValidators _validatorRegistration;
        private readonly ILogger<ISolverService> _logger;

        public SolverService(ILogger<ISolverService> logger, IDefaultValidators validatorRegistration = null)
        {
            _logger = logger;
            _validatorRegistration = validatorRegistration;
        }

        public bool Solve<T>(int height, int width, IList<T> items, out IAtlas<T> atlasOutput, IList<IValidator> validators = null) where T : IItem
        {
            _logger.LogTrace($"SolverService.Solve({height}, {width}, {items}, {validators}) invoked.");

            // determine which validators we should use
            IList<IValidator> validatorsToUse = new List<IValidator>();
            
            if (_validatorRegistration != null)
                validatorsToUse = _validatorRegistration.GetValidators();
            
            if (validators != null)
                validatorsToUse = validators;

            if (validatorsToUse == null)
                validatorsToUse = new List<IValidator>();

            var solver = new AtlasSolver<T>() { Items = items, Validators = validatorsToUse, Width = width, Height = height };
 
            // run the solver
            try
            {
                atlasOutput = solver.Solve();
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
                atlasOutput = null;
            }

            _logger.LogTrace($"SolverService.Solve finished.");

            if (atlasOutput == null)
                return false;

            return true;
        }
    }
}
