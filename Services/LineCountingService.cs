using BlackLineCountChecker.Interfaces;
using BlackLineCountChecker.Models;
using System.Drawing;

namespace BlackLineCountChecker.Services
{
    /// <summary>
    /// Orchestrates image processing workflow for detecting and counting vertical lines.
    /// </summary>
    public class LineCountingService
    {
        private readonly IImageLoader _imageLoader;
        private readonly ILineDetector _lineDetector;
        private readonly IInputValidator _validator;

        /// <summary>
        /// Initializes the service with required dependencies.
        /// </summary>
        public LineCountingService(
            IImageLoader imageLoader,
            ILineDetector lineDetector,
            IInputValidator validator)
        {
            _imageLoader = imageLoader;
            _lineDetector = lineDetector;
            _validator = validator;
        }

        /// <summary>
        /// Processes an image to detect and count vertical black lines.
        /// </summary>
        public ImageProcessingResult ProcessImage(string imagePath)
        {

            // Validate the image path - throws ValidationException if invalid image path
            var validationResult = _validator.ValidateImagePath(imagePath);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage ?? "Validation failed.");
            }
            string imageName = Path.GetFileName(imagePath);

            // Load and process the image 
            using (Bitmap image = _imageLoader.LoadImage(imagePath))
            {
                int lineCount = _lineDetector.CountVerticalLines(image);
                return new ImageProcessingResult
                {
                    ImageName = imageName,
                    LineCount = lineCount
                };

            }
        }
    }
}
