using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RectBinPacker.DesktopApp.Services
{
    public class ImageLoaderService : IImageLoaderService
    {
        private readonly ILogger<IImageLoaderService> _logger;
        public ImageLoaderService(ILogger<IImageLoaderService> logger)
        {
            _logger = logger;
        }

        public bool LoadImage(string filePath, out Bitmap image, out string exceptionMessage)
        {
            _logger.LogTrace($"ImageLoaderService.LoadImage({filePath}) invoked.");

            image = null;
            exceptionMessage = null;

            try
            {
                image = new Bitmap(filePath);
                _logger.LogTrace($"ImageLoaderService.LoadImage({filePath}) finished successfully.");
                return true;
            } catch (Exception e)
            {
                exceptionMessage = e.Message;
                _logger.LogTrace($"ImageLoaderService.LoadImage({filePath}) finished with an exception of: '{ exceptionMessage}'.");
                return false;
            }
        }

    }
}
