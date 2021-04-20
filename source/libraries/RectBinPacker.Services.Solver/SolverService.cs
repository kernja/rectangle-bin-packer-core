using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RectBinPacker.Services.Solver
{
    public class SolverService : ISolverService
    {
        public bool IsConfigured()
        {
            throw new NotImplementedException();
        }

        public IAtlas Solve(IList<IItem> items, IList<IValidator> validators)
        {
            throw new NotImplementedException();
        }
    }
}
