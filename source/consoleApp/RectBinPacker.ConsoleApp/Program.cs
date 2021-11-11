using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                .AddLogging(config =>
                {
                    config.ClearProviders().AddConsole();
                })
                .AddScoped<IDefaultValidators, DefaultValidators>()
                .AddScoped<IAtlasConsoleOutputService, AtlasConsoleOutputService>()
                .AddTransient<ISolverService, SolverService>()
                .BuildServiceProvider();

            // get our solver service
            var solverService = serviceProvider.GetService<ISolverService>();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

            // generate a test atlas to generate
            IAtlas<TextItem> atlasOutput = null;
            var result = solverService.Solve(50, 100, new List<TextItem>
            {
                new TextItem { Width = 25, Height = 25, Character = 'a' },
                new TextItem { Width = 25, Height = 50, Character = 'B' },
                new TextItem { Width = 5, Height = 5, Character = 'c' },
                new TextItem { Width = 9, Height = 14, Character = 'D' },
                new TextItem { Width = 25, Height = 3, Character = 'e' }
            }, out atlasOutput);

            if (result)
            {
                // generate our output
                var outputService = serviceProvider.GetService<IAtlasConsoleOutputService>();
                var output = outputService.GenerateConsoleOutput<TextItem>(atlasOutput);

                // print it to screen
                foreach (var line in output)
                    Console.WriteLine(line);
            } else
            {
                Console.WriteLine("Unable to generate atlas.");
            }

            serviceProvider.Dispose();
            Console.WriteLine("");
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}