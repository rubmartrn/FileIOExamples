﻿namespace UniversityProgram.Api.Models;

public class Result
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public ErrorType ErrorType { get; set; }

    public static Result Ok(string? message = default)
    {
        return new Result { Success = true, Message = message };
    }

    public static Result Error(ErrorType type, string? message = default)
    {
        return new Result { Success = false, ErrorType = type, Message = message };
    }
}

public class Result<T> : Result
{
    public T? Data { get; set; }

    public static Result<T> Ok(T data, string? message = default)
    {
        return new Result<T> { Success = true, Data = data, Message = message };
    }

    public static new Result<T> Error(ErrorType type, string? message = default)
    {
        return new Result<T> { Success = false, ErrorType = type, Message = message };
    }
}