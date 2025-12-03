using BlackLineCountChecker.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Drawing;

namespace BlackLineCountChecker.Services
{

    public class VerticalBlackLineDetector : ILineDetector
    {
        private readonly int _blackThreshold;

        /// <summary>
        /// Initializes  the threshold from configuration or set default value.
        /// </summary>
        public VerticalBlackLineDetector(IConfiguration configuration)
        {
            _blackThreshold = configuration.GetValue<int>("ImageProcessing:BlackThreshold");

        }
        /// <summary>
        /// step 1 : Counts vertical black lines by scanning the middle row horizontally.
        /// step 2 : Detects white-to-black transitions and verifies vertical continuity of blcak line.
        /// </summary>
        public int CountVerticalLines(Bitmap image)
        {
            int img_width = image.Width;
            int img_height = image.Height;

            // Use the middle row to scan for vertical lines
            int scanRow = img_height / 2;

            int lineCount = 0;
            bool isBlackRegion = false;

            // Scan horizontally across the middle of the image
            for (int x = 0; x < img_width; x++)
            {
                Color pixel = image.GetPixel(x, scanRow);

                // Check if pixel is black 
                bool isBlack = IsBlackPixel(pixel);

                // Detect transition from white to black (start of a new line)
                if (isBlack && !isBlackRegion)
                {
                    // Verify this is a vertical line by checking pixels above and below
                    if (IsVerticalLine(image, x, scanRow))
                    {
                        lineCount++;
                    }
                    isBlackRegion = true;
                }
                else if (!isBlack && isBlackRegion)
                {
                    // To Detect (end of line)
                    isBlackRegion = false;
                }
            }

            return lineCount;
        }

        /// <summary>
        /// Checks if a pixel is black based on the configured threshold.
        /// </summary>
        private bool IsBlackPixel(Color pixel)
        {
            return pixel.R < _blackThreshold && pixel.G < _blackThreshold && pixel.B < _blackThreshold;
        }

        /// <summary>
        /// Verifies a black region is a vertical line by checking top and bottom quarters.
        /// </summary>
        private bool IsVerticalLine(Bitmap image, int x, int centerY)
        {
            int height = image.Height;

            // Sample points in top quarter and bottom quarter
            int toplineY = height / 4;
            int bottomlineY = (3 * height) / 4;

            // Ensure scanning don't go out of bounds
            if (toplineY < 0 || bottomlineY >= height)
            {
                return false;
            }

            // Check if the column has black pixels in both top and bottom sections

            bool hasTopBlack = IsBlackPixel(image.GetPixel(x, toplineY));
            bool hasBottomBlack = IsBlackPixel(image.GetPixel(x, bottomlineY));

            return hasTopBlack && hasBottomBlack;
        }
    }
}