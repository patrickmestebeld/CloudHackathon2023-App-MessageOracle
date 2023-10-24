using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MessageOracle.Shared.GuardClauses;

namespace MessageOracle.Shared.CustomGuards;

public static class GuardAgainstInvalidPostcodeExtensions
{
    public static void InvalidPostcode(this IGuardClause _, string input, [CallerArgumentExpression("input")] string? parameterName = null, string? message = null)
    {
        if (!Regex.IsMatch(input, @"^([0-9]{4}[A-Z]{2})$"))
        {
            throw new ArgumentException(message ?? $"Input {parameterName} is geen valide postcode", parameterName);
        }
    }
}
