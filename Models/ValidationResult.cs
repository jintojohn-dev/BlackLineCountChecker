namespace BlackLineCountChecker.Models
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public string? ErrorMessage { get; set; }
    }
}