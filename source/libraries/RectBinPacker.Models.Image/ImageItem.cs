using RectBinPacker.Interfaces;
using System;
using System.Drawing;

namespace RectBinPacker.Models.Image
{
    public class ImageItem : IItem
    {
        public Bitmap Image { get; set; }

        public int Width 
        {
            get
            {
                if (Image == null)
                    return 0;

                return Image.Width;
            }
        }

        public int Height
        {
            get
            {
                if (Image == null)
                    return 0;

                return Image.Height;
            }
        }
    }
}
