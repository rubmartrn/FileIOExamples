namespace UniversityProgram.Api.Models
{
    public class Result
    {
        public Result(bool success, string errorMessage)
        {
            Success = success;
            Message = errorMessage;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = default!;

        public string ErrorCode { get; set; } = default!;

    }

    public class ErrorCodes
    {
        public const string NotFound = "NotFound";
        public const string BadRequest = "BadRequest";
        public const string InternalServerError = "InternalServerError";
    }
}
