using RectBinPacker.DesktopApp.Adapters;
using RectBinPacker.DesktopApp.Models;
using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace RectBinPacker.DesktopApp.Services
{
    public class AppService : IAppService
    {
        private readonly IList<ImageListItem> _imageList;
        private readonly IImageLoaderService _imageLoaderService;
        private readonly IImageAdapter _imageAdapter;
        private readonly IFilePickerService _filePickerService;
        private readonly ISolverService _solverService;
        private readonly IImageDrawerService _imageDrawerService;
        private readonly ILogger<IAppService> _logger;
        public AppService(ILogger<IAppService> logger, IImageLoaderService imageLoaderService, IImageAdapter imageAdapter, IFilePickerService filePickerService, ISolverService solverService, IImageDrawerService imageDrawerService)
        {
            _imageList = new List<ImageListItem>();
            _imageLoaderService = imageLoaderService;
            _imageAdapter = imageAdapter;
            _filePickerService = filePickerService;
            _solverService = solverService;
            _imageDrawerService = imageDrawerService;
            _logger = logger;
        }

        public bool AddImage(out string exceptionMessage)
        {
            _logger.LogTrace("AppService.AddImage() invoked.");

            exceptionMessage = null;
            string filePath;
            string fileName;
            bool result = false;
            if (_filePickerService.SelectFile("Select file...", "PNG Files|*.png", out filePath, out fileName))
            {
                Bitmap bitmap;

                if (_imageLoaderService.LoadImage(filePath, out bitmap, out exceptionMessage))
                {
                    _imageList.Add(new ImageListItem
                    {
                         Image = bitmap,
                          Name = fileName,
                          Path = filePath
                    });

                    result = true;
                }
            }

            _logger.LogTrace($"AppService.AddImage() finished and returned '{result}'");
            return result;
        }

        public IList<ImageListItem> GetImageListItems()
        {
            _logger.LogTrace("AppService.GetImageListItems() invoked.");
            _logger.LogTrace($"AppService.GetImageListItems() finished and returned '{_imageList}'");
            return _imageList;
        }

        public bool RemoveImageListItem(ImageListItem item)
        {
            _logger.LogTrace($"AppService.RemoveImageListItem({item}) invoked.");
            _logger.LogTrace($"AppService.RemoveImageListItem({item}) finished.");
            return _imageList.Remove(item);
        }
        public bool Solve(out Bitmap output)
        {
            _logger.LogTrace("AppService.Solve() invoked.");

            IAtlas<ImageItem> atlasOutput = null;
            var result = _solverService.Solve<ImageItem>(512, 512, 
                    _imageList.Select(il => _imageAdapter.Adapt(il)).ToList(),
                    out atlasOutput);

                
            if (result)
            {
                output = _imageDrawerService.DrawAtlas<ImageItem>(atlasOutput);
            } else
            {
                output = null;
            }

            _logger.LogTrace($"AppService.Solve() finished and returned '{result}'");
            return result;
        }
    }
}
