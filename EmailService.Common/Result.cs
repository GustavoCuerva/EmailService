namespace EmailService.Common;

public class Result
{
	public bool IsSuccess { get; }
	public virtual bool IsFailure => !IsSuccess;

	public List<Error> Errors { get; }

	private protected Result(bool isSuccess, IEnumerable<Error> errors)
	{
		IsSuccess = isSuccess;
		Errors = [.. errors];
	}

	public static Result Success() => new(true, []);
	public static Result<T> Success<T>(T data) => new(true, [], data);

	public static Result Fail(Error error) => new(false, [error]);
	public static Result Fail(IEnumerable<Error> errors) => new(false, errors);

	public static Result<T> Fail<T>(Error error) => new(false, [error], default!);
	public static Result<T> Fail<T>(IEnumerable<Error> errors) => new(false, errors, default!);

	public static implicit operator Result(Error error) => Fail(error);
	public static implicit operator Result(List<Error> error) => Fail(error);
}