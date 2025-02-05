using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Net;
using UniversityProgram.Api.Exceptions.HttpException;

namespace UniversityProgram.Api.Validators.ObjectValidator
{
    public static class ObjectValidator
    {
        public static void ThrowIfNull(object? @object, string message = "Not Found", HttpStatusCode code = HttpStatusCode.NotFound)
        {
            if (@object is null) throw new HttpException(code, message);
        }

        public static void ThrowIfInvalid(FluentValidation.Results.ValidationResult result, string message = "Invalid Data", HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            if (!result.IsValid) throw new HttpException(code, message);
        }
    }
}
