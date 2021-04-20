using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RectBinPacker.Services.Solver
{
    public class SolverService : ISolverService
    {
        public ISolver CreateSolver()
        {
            return new Solver();
        }

        public ISolver CreateSolver(IList<IItem> items, IList<ISolverValidator> validators)
        {
            throw new NotImplementedException();
        }
    }
}
