﻿using System.ComponentModel.DataAnnotations;

namespace CGOL.Lib.Exceptions;

public class OptionValidationFailedException : Exception
{
    public IEnumerable<ValidationResult> ValidationResults { get; }

    public OptionValidationFailedException(IEnumerable<ValidationResult> validationResults) : base("Validation of launch options has failed!")
    {
        ValidationResults = validationResults;
    }
}