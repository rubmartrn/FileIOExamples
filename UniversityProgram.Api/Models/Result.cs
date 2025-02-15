namespace UniversityProgram.Api.Models;

public class Result
{
    public Result(bool success, string errorMessage, ErrorType errorType = default)
    {
        Success = success;
        Message = errorMessage;
        ErrorType = errorType;
    }

    public bool Success { get; set; }
    public string Message { get; set; } = default!;

    public ErrorType ErrorType { get; set; }
}