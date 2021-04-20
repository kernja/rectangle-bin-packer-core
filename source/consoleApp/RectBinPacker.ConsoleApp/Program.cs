using Microsoft.Extensions.DependencyInjection;
using RectBinPacker.ConsoleApp;
using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver;
using System;
using System.Collections.Generic;

namespace RectBinPacker.ConsoleApp_
{
    class Program
    {
        private class Item : IItem
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        static void Main(string[] args)
        {
            // configure our dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IValidatorRegistration, ValidatorRegistration>()
                .AddScoped<ISolverService, SolverService>()
                .BuildServiceProvider();

            // get our solver service
            var solverService = serviceProvider.GetService<ISolverService>();

            // run our solver
            var atlas = solverService.Solve(128, 128, new List<IItem>
            {
                new Item { Width = 64, Height = 32 },
                new Item { Width = 64, Height = 128 },
                new Item { Width = 128, Height = 128 },
                new Item { Width = 64, Height = 32 },
                new Item { Width = 256, Height = 128 }
            });


            Console.WriteLine("Hello World!");
        }
    }
}