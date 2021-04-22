using System;
using System.Collections.Generic;
using System.Text;

namespace RectBinPacker.DesktopApp.Services
{
    public interface IFilePickerService
    {
        bool SelectFile(string title, string filter, out string filePath, out string fileName);
    }
}
