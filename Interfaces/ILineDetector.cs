using System.Drawing;

namespace BlackLineCountChecker.Interfaces
{
    public interface ILineDetector
    {
        int CountVerticalLines(Bitmap image);
    }
}
