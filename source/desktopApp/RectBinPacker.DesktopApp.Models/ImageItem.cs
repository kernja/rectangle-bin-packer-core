using RectBinPacker.Interfaces;
using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace RectBinPacker.DesktopApp.Models
{
    [DataContract]
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
