namespace TABP.Application.Responses;

public class Result
{
    public bool IsSuccess { get; private set; }
    public string ErrorMessage { get; private set; }

    public static Result Success() => new Result { IsSuccess = true };
    public static Result Fail(string errorMessage) => new Result { IsSuccess = false, ErrorMessage = errorMessage };
}