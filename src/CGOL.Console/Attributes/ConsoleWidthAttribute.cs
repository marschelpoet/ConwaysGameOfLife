using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CGOL.Console.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class ConsoleWidthAttribute : ValidationAttribute
{
    private new const string ErrorMessage = "The field {0} must be between {1} and {2}.";
    private readonly int _minimumWidth;
    private readonly int _maxWidth = System.Console.LargestWindowWidth;

    public ConsoleWidthAttribute()
    {

    }

    public ConsoleWidthAttribute(int minimumWidth)
    {
        _minimumWidth = minimumWidth;
    }

    /// <inheritdoc />
    public override string FormatErrorMessage(string name)
    {
        return string.Format(CultureInfo.CurrentCulture, ErrorMessage, name, _minimumWidth, _maxWidth);
    }

    /// <inheritdoc />
    public override bool IsValid(object? value)
    {
        if (value == null || (value as string)?.Length == 0)
        {
            return false;
        }

        int convertedValue = (int)value;

        return convertedValue >= _minimumWidth && convertedValue <= _maxWidth;
    }
}