using BlackLineCountChecker.Interfaces;
using BlackLineCountChecker.Models;

namespace BlackLineCountChecker.Services
{
    /// <summary>
    /// Validates command-line arguments and image file paths.
    /// </summary>
    public class InputValidator : IInputValidator
    {
        /// <summary>
        /// Validates that exactly one argument is provided.
        /// </summary>
        public ValidationResult ValidateArguments(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Error: No arguments provided. Please provide the absolute path to an image file."
                };
            }

            if (args.Length > 1)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Error: Too many arguments provided. Please provide exactly one argument (the image path)."
                };
            }

            return new ValidationResult { IsValid = true };
        }

        /// <summary>
        /// Validates that the image path exists and is a JPG/JPEG file.
        /// </summary>
        public ValidationResult ValidateImagePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Error: Image path cannot be empty."
                };
            }

            if (!File.Exists(path))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = $"Error: File not found at path: {path}"
                };
            }

            string extension = Path.GetExtension(path).ToLower();
            if (extension != ".jpg" && extension != ".jpeg")
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = $"Error: Invalid file format. Expected JPG file, got: {extension}"
                };
            }

            return new ValidationResult { IsValid = true };
        }
    }
}
