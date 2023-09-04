using CGOL.Lib.Exceptions;

using System.ComponentModel.DataAnnotations;

namespace CGOL.Lib.Services;

public class DefaultOptionsValidator<TOptions> : IOptionsValidator<TOptions> where TOptions : notnull
{
    public void ValidateOptionsThrow(TOptions options)
    {
        List<ValidationResult> results = new();
        ValidationContext context = new(options);

        if (!Validator.TryValidateObject(options, context, results, true))
        {
            throw new OptionValidationFailedException(results);
        }
    }
}