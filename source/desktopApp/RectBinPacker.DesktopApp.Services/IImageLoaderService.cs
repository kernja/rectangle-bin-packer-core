using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RectBinPacker.DesktopApp.Services
{
    public interface IImageLoaderService
    {
        bool LoadImage(string filePath, out Bitmap bitmap, out string exceptionMessage);
    }
}
