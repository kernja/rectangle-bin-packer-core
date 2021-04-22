using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RectBinPacker.DesktopApp.Services
{
    public class ImageLoaderService : IImageLoaderService
    {
        public bool LoadImage(string filePath, out Bitmap image, out string exceptionMessage)
        {
            image = null;
            exceptionMessage = null;

            try
            {
                image = new Bitmap(filePath);
                return true;
            } catch (Exception e)
            {
                exceptionMessage = e.Message;
                return false;
            }
        }

    }
}
