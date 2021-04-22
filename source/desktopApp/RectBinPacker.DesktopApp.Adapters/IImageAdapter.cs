using RectBinPacker.DesktopApp.Models;

namespace RectBinPacker.DesktopApp.Adapters
{
    public interface IImageAdapter
    {
        ImageItem Adapt(ImageListItem item);

        ImageListItem Adapt(ImageItem item);
    }
}
