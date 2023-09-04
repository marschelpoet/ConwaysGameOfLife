using CGOL.Console.Constants;

using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CGOL.Console.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class ConsoleHeightAttribute : ValidationAttribute
{
    private new const string ErrorMessage = "The field {0} must be between {1} and {2}.";

    private readonly int _minimumHeight;
    // Reduce available height to User to have space for the menu print
    private readonly int _maxHeight = System.Console.LargestWindowHeight - ConsoleConstants.NumberOfReservedBufferRows;

    public ConsoleHeightAttribute(int minimumHeight)
    {
        _minimumHeight = minimumHeight;
    }

    /// <inheritdoc />
    public override string FormatErrorMessage(string name)
    {
        return string.Format(CultureInfo.CurrentCulture, ErrorMessage, name, _minimumHeight, _maxHeight);
    }

    /// <inheritdoc />
    public override bool IsValid(object? value)
    {
        if (value == null || (value as string)?.Length == 0)
        {
            return false;
        }

        int convertedValue = (int)value;

        return convertedValue >= _minimumHeight && convertedValue <= _maxHeight;
    }
}