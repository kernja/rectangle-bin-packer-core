using RectBinPacker.Interfaces;
using System;
using System.Runtime.Serialization;

namespace RectBinPacker.ConsoleApp.Models
{
    [DataContract]
    public class TextItem : IItem, ITextItem
    {
        public char Character { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
