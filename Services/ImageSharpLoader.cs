using BlackLineCountChecker.Interfaces;
using System.Drawing;

namespace BlackLineCountChecker.Services
{
    /// <summary>
    /// Loads images 
    /// </summary>
    internal class ImageSharpLoader : IImageLoader
    {
        /// <summary>
        /// Loads an image from the specified file path.
        /// </summary>
        public Bitmap LoadImage(string path)
        {
            return new Bitmap(path);
        }
    }
}
