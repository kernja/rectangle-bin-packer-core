using RectBinPacker.DesktopApp.Models;
using System;

namespace RectBinPacker.DesktopApp.Adapters
{
    public class ImageAdapter : IImageAdapter
    {
        public ImageItem Adapt(ImageListItem item)
        {
            if (item == null || item.Image == null)
                throw new ArgumentNullException("item", "ImageAdapter.Adapt(ImageListItem) failed. Item was null, or referenced a null image.");
            
            return new ImageItem { Image = item.Image };
        }

        public ImageListItem Adapt(ImageItem item)
        {
            if (item == null || item.Image == null)
                throw new ArgumentNullException("item", "ImageAdapter.Adapt(ImageItem) failed. Item was null, or referenced a null image.");

            return new ImageListItem { Image = item.Image, Name = item.Image.GetHashCode().ToString(), Path = null };
        }
    }
}
