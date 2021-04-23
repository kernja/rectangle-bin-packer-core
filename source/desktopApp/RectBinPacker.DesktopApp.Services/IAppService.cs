using RectBinPacker.DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RectBinPacker.DesktopApp.Services
{
    public interface IAppService
    {
        bool AddImage(out string exceptionMessage);
        bool RemoveImageListItem(ImageListItem item);
        IList<ImageListItem> GetImageListItems();

        bool Solve(out Bitmap output);
    }
}
