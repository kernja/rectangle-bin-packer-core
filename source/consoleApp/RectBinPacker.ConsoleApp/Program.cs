using Microsoft.Extensions.DependencyInjection;
using RectBinPacker.ConsoleApp;
using RectBinPacker.ConsoleApp.Models;
using RectBinPacker.ConsoleApp.Services;
using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver;
using System;
using System.Collections.Generic;

namespace RectBinPacker.ConsoleApp_
{
    class Program
    {
        static void Main(string[] args)
        {
            // configure our dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IDefaultValidators, DefaultValidators>()
                .AddScoped<IAtlasConsoleOutputService, AtlasConsoleOutputService>()
                .AddTransient<ISolverService, SolverService>()
                .BuildServiceProvider();

            // get our solver service
            var solverService = serviceProvider.GetService<ISolverService>();

            // generate a test atlas to generate
            var atlas = solverService.Solve(50, 100, new List<TextItem>
            {
                new TextItem { Width = 25, Height = 25, Character = 'a' },
                new TextItem { Width = 25, Height = 50, Character = 'B' },
                new TextItem { Width = 5, Height = 5, Character = 'c' },
                new TextItem { Width = 9, Height = 14, Character = 'D' },
                new TextItem { Width = 25, Height = 3, Character = 'e' }
            });

            // generate our output
            var outputService = serviceProvider.GetService<IAtlasConsoleOutputService>();
            var output = outputService.GenerateConsoleOutput<TextItem>(atlas);

            // print it to screen
            foreach (var line in output)
                Console.WriteLine(line);

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}