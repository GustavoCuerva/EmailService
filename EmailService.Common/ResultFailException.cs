using EmailService.Common;
using System.Collections.Immutable;

namespace Affinity.WebServiceAPI.Common;

public class ResultFailException : Exception
{
	private readonly ImmutableList<Error> _errors;
	public IReadOnlyList<Error> Errors => _errors;

	internal ResultFailException(IEnumerable<Error> errors)
		: base($"Tentativa de acesso no valor de um resultado falho. O erro era: {errors}")
		=> _errors = [.. errors];
}