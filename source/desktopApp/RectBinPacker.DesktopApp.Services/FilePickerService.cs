using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Windows.Forms;

namespace RectBinPacker.DesktopApp.Services
{
    public class FilePickerService : IFilePickerService
    {
        private readonly ILogger<IFilePickerService> _logger;
        public FilePickerService(ILogger<IFilePickerService> logger)
        {
            _logger = logger;
        }

        public bool SelectFile(string title, string filter, out string filePath, out string fileName)
        {
            _logger.LogInformation($"FilePickerService.SelectFile({title}, {filter}) invoked.");

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

                    _logger.LogInformation($"FilePickerService.SelectFile({title}, {filter}) finished with '{filePath}' being selected.");
                    return true;
                }

                _logger.LogInformation($"FilePickerService.SelectFile({title}, {filter}) finished without a file being selected.");
                return false;
            }
        }
    }
}
