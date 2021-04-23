using RectBinPacker.ConsoleApp.Models;
using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace RectBinPacker.ConsoleApp.Services
{
    public class AtlasConsoleOutputService : IAtlasConsoleOutputService
    {
        private const char ConstEmptySpace = '.';
        private const string ConstStart = "-----GENERATED ATLAS IS BELOW-----";
        private const string ConstEnd = "-----GENERATED ATLAS IS ABOVE-----";

        private readonly ILogger<IAtlasConsoleOutputService> _logger;
        public AtlasConsoleOutputService(ILogger<IAtlasConsoleOutputService> logger)
        {
            _logger = logger;
        }

        public IList<string> GenerateConsoleOutput<T>(IAtlas<T> atlas) where T : ITextItem, IItem
        {
            _logger.LogTrace($"AtlasConsoleOutputService.GenerateConsoleOutput({atlas}) invoked.");
            
            if (atlas == null)
            {
                _logger.LogTrace($"AtlasConsoleOutputService.GenerateConsoleOutput({atlas}) finished due to a null atlas being passed in.");
                return new List<string>();
            }

            var outputList = new List<string> { ConstStart };
            var configuredItems = atlas.GetConfiguredItems();

            for (int y = 0; y < atlas.Height; y++)
            {
                string outputString = "";
                for (int x = 0; x < atlas.Width; x++)
                {
                    var item = configuredItems.Where(ci => ((ci.X <= x && ((ci.X + ci.Width) > x)) && 
                            (ci.Y <= y && ((ci.Y + ci.Height) > y)))).FirstOrDefault();

                    if (item != null)
                    {
                        outputString = outputString + item.OriginalItem.Character.ToString();
                    } else
                    {
                        outputString = outputString + ConstEmptySpace.ToString();
                    }
                }

                outputList.Add(outputString);
            }
            outputList.Add(ConstEnd);

            _logger.LogTrace($"AtlasConsoleOutputService.GenerateConsoleOutput({atlas}) finished.");
            return outputList;
        }
    }
}
