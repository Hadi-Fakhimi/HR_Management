using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace HR_Management.Application.Exceptions
{
    public class ValidationException:ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
