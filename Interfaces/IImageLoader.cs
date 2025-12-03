using System.Drawing;

namespace BlackLineCountChecker.Interfaces
{
    public interface IImageLoader
    {
        Bitmap LoadImage(string path);
    }
}
