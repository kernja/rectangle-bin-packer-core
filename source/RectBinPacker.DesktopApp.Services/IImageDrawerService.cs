using RectBinPacker.DesktopApp.Models;
using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RectBinPacker.DesktopApp.Services
{
    public interface IImageDrawerService
    {
        Bitmap DrawAtlas<T>(IAtlas<T> atlas) where T : ImageItem, IItem;
    }
}
