using RectBinPacker.DesktopApp.Adapters;
using RectBinPacker.DesktopApp.Models;
using RectBinPacker.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;

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
        public AppService(IImageLoaderService imageLoaderService, IImageAdapter imageAdapter, IFilePickerService filePickerService, ISolverService solverService, IImageDrawerService imageDrawerService)
        {
            _imageList = new List<ImageListItem>();
            _imageLoaderService = imageLoaderService;
            _imageAdapter = imageAdapter;
            _filePickerService = filePickerService;
            _solverService = solverService;
            _imageDrawerService = imageDrawerService;
        }

        public bool AddImage(out string exceptionMessage)
        {
            exceptionMessage = null;
            string filePath;
            string fileName;

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

                    return true;
                }
            }

            return false;
        }

        public IList<ImageListItem> GetImageListItems()
        {
            return _imageList;
        }

        public bool RemoveImageListItem(ImageListItem item)
        {
            return _imageList.Remove(item);
        }
        public Bitmap Solve()
        {
            var atlas = _solverService.Solve<ImageItem>(512, 512, _imageList.Select(il => _imageAdapter.Adapt(il)).ToList());
            var bitmap = _imageDrawerService.DrawAtlas<ImageItem>(atlas);
            return bitmap;
        }

    }
}
