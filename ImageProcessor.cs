using BlackLineCountChecker.Interfaces;
using BlackLineCountChecker.Services;

namespace BlackLineCountChecker
{
    /// <summary>
    /// Main application that coordinates the image processing workflow.
    /// </summary>
    public class ImageProcessor
    {
        private readonly LineCountingService _lineCountingService;
        private readonly IInputValidator _validator;

        /// <summary>
        /// Initializes the processor with required dependencies.
        /// </summary>
        public ImageProcessor(
            LineCountingService lineCountingService,
            IInputValidator validator)
        {
            _lineCountingService = lineCountingService;
            _validator = validator;
        }

        /// <summary>
        /// Validates arguments, processes the image, and outputs results.
        /// </summary>
        public void Run(string[] args)
        {

            // Validate number of arguments
            var argValidation = _validator.ValidateArguments(args);
            if (!argValidation.IsValid)
            {
                Console.WriteLine(argValidation.ErrorMessage);
                Console.WriteLine("\nUsage: BlackLineCountChecker.exe <absolute_path_to_image>");
                Console.WriteLine(@"Example: BlackLineCountChecker.exe C:\user\Toyota\BlackLineCountChecker\images\img_1.jpg");

                return;
            }

            string imagePath = args[0];

            // Process the image 
            var result = _lineCountingService.ProcessImage(imagePath);

            // Output result
            Console.WriteLine($"Image Name: {result.ImageName}, Vertical Line Count: {result.LineCount}");
        }
    }

}

