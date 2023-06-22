using System.ComponentModel.DataAnnotations;

namespace CGOL.Console.Services.Interfaces;

public interface IOptionsValidator
{
    void ValidateOptionsThrow(LaunchOptions options)
    {
        List<ValidationResult> results = new();
        ValidationContext context = new(options);

        if (!Validator.TryValidateObject(options, context, results, true))
        {
            throw new OptionValidationFailedException(results);
        }
    }
}