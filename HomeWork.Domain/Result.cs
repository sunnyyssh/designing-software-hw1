using System.Diagnostics.CodeAnalysis;

namespace HomeWork.Domain;

public enum ErrorType 
{
    None,
    NotFound,
    UnknownError,
    ValidationFailed,
}

public sealed class ValidationError 
{
    public ValidationError(string field, string message)
    {
        Field = field;
        Message = message;
    }

    public string Field { get; }

    public string Message { get; }
} 

public sealed class Result<TResult> 
{
    public static Result<TResult> Success(TResult res) => new(res, ErrorType.None, []);

    public static Result<TResult> UnknownError() => new(default, ErrorType.UnknownError, []);

    public static Result<TResult> NotFound() => new(default, ErrorType.NotFound, []);

    public static Result<TResult> ValidationFailed(IEnumerable<ValidationError> validationErrors) 
        => new(default, ErrorType.ValidationFailed, validationErrors);

    public static Result<TResult> WrapError<TAnother>(Result<TAnother> another)
        => new(default, another.Error, another.ValidationErrors);

    public static Result<TResult> Map<TAnother>(Result<TAnother> another, Func<TAnother, TResult> convert) 
        => another.IsSuccess ? Success(convert(another.Value)) : WrapError(another); 

    private Result(TResult? res, ErrorType error, IEnumerable<ValidationError> validationErrors) 
    {
        Value = res;
        Error = error;
        ValidationErrors = validationErrors ?? [];
    }

    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess => Error == ErrorType.None;

    public TResult? Value { get; }

    public ErrorType Error { get; }

    public IEnumerable<ValidationError> ValidationErrors { get; }
}
