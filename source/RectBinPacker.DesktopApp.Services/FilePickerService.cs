using System;
using System.IO;
using System.Windows.Forms;

namespace RectBinPacker.DesktopApp.Services
{
    public class FilePickerService : IFilePickerService
    {
        public bool SelectFile(string title, string filter, out string filePath, out string fileName)
        {
            filePath = null;
            fileName = null;

            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = filter;
                dialog.Title = title;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.SafeFileName;
                    filePath = dialog.FileName;
                    return true;
                }

                return false;
            }
        }
    }
}
