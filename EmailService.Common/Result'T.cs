namespace EmailService.Common;

public sealed class Result<T> : Result
{
	private readonly T _data;
	public T Data => IsSuccess ? _data : throw new ResultFailException(Errors);

	internal Result(bool isSuccess, IEnumerable<Error> errors, T data) : base(isSuccess, errors) => _data = data;

	public static implicit operator Result<T>(T data) => Success(data);
	public static implicit operator Result<T>(Error error) => Fail<T>(error);
	public static implicit operator Result<T>(List<Error> errors) => Fail<T>(errors);
	public static implicit operator T(Result<T> result) => result.IsSuccess ? result.Data : throw new ResultFailException(result.Errors);
}