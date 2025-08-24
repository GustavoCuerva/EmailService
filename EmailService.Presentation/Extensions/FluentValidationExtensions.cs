using EmailService.Common;
using FluentValidation.Results;

namespace EmailService.Presentation.Extensions
{
    public static class FluentValidationExtensions
    {
        public static List<Error> ToErrorList(this ValidationResult result)
            => result.ToDictionary().SelectMany(KeyValuePair => KeyValuePair.Value.Select(msg => new Error(KeyValuePair.Key, msg))).ToList();
    }
}
