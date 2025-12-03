

using BlackLineCountChecker.Models;

namespace BlackLineCountChecker.Interfaces
{
    public interface IInputValidator
    {
        ValidationResult ValidateArguments(string[] args);
        ValidationResult ValidateImagePath(string path);
    }
}
