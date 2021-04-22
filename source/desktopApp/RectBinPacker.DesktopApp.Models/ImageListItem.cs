using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace RectBinPacker.DesktopApp.Models
{
    [DataContract]
    public class ImageListItem
    {
        public Bitmap Image { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
