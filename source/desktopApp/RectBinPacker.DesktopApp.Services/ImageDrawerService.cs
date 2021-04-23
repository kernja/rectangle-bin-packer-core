using Microsoft.Extensions.Logging;
using RectBinPacker.DesktopApp.Models;
using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RectBinPacker.DesktopApp.Services
{
    public class ImageDrawerService : IImageDrawerService
    {
        private readonly ILogger<IImageDrawerService> _logger;
        public ImageDrawerService(ILogger<IImageDrawerService> logger)
        {
            _logger = logger;
        }

        public Bitmap DrawAtlas<T>(IAtlas<T> atlas) where T : ImageItem, IItem
        {
            _logger.LogTrace($"ImageDrawerService.DrawAtlas({atlas}) invoked.");

            using (var bitmap = new Bitmap(atlas.Width, atlas.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    foreach (var ci in atlas.GetConfiguredItems())
                    {
                        graphics.DrawImage(ci.OriginalItem.Image, ci.X, ci.Y, ci.Width, ci.Height);
                    }
                }

                _logger.LogTrace($"ImageDrawerService.DrawAtlas({atlas}) finished.");
                return (Bitmap)bitmap.Clone();
            }
        }

    }
}
