using RectBinPacker.ConsoleApp.Models;
using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RectBinPacker.ConsoleApp.Services
{
    public class AtlasConsoleOutputService : IAtlasConsoleOutputService
    {
        private const char ConstEmptySpace = '.';
        private const string ConstStart = "-----GENERATED ATLAS IS BELOW-----";
        private const string ConstEnd = "-----GENERATED ATLAS IS ABOVE-----";

        public IList<string> GenerateConsoleOutput<T>(IAtlas<T> atlas) where T : ITextItem, IItem
        {
            if (atlas == null)
                return new List<string>();

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
            return outputList;
        }
    }
}
