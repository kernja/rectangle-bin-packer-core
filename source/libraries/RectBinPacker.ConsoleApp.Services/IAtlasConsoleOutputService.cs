using RectBinPacker.ConsoleApp.Models;
using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.ConsoleApp.Services
{
    public interface IAtlasConsoleOutputService
    {
        IList<string> GenerateConsoleOutput<T>(IAtlas<T> atlas) where T : ITextItem, IItem;
    }
}
