﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MessageOracle.Shared.GuardClauses;

public static partial class GuardClauseExtensions
{
    public static int EnumOutOfRange<T>(this IGuardClause guardClause,
        int input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null) where T : struct, Enum
    {
        if (!Enum.IsDefined(typeof(T), input))
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new InvalidEnumArgumentException(parameterName, input, typeof(T));
            }
            throw new InvalidEnumArgumentException(message);
        }

        return input;
    }

    public static T EnumOutOfRange<T>(this IGuardClause guardClause,
        T input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null) where T : struct, Enum
    {
        if (!Enum.IsDefined(typeof(T), input))
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new InvalidEnumArgumentException(parameterName, Convert.ToInt32(input), typeof(T));
            }
            throw new InvalidEnumArgumentException(message);
        }

        return input;
    }

    public static IEnumerable<T> OutOfRange<T>(this IGuardClause guardClause,
        IEnumerable<T> input,
        string parameterName,
        T rangeFrom, T rangeTo,
        string? message = null) where T : IComparable, IComparable<T>
    {
        if (rangeFrom.CompareTo(rangeTo) > 0)
        {
            throw new ArgumentException(message ?? $"{nameof(rangeFrom)} should be less or equal than {nameof(rangeTo)}", parameterName);
        }

        if (input.Any(x => x.CompareTo(rangeFrom) < 0 || x.CompareTo(rangeTo) > 0))
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentOutOfRangeException(parameterName, message ?? $"Input {parameterName} had out of range item(s)");
            }
            throw new ArgumentOutOfRangeException(parameterName, message);
        }

        return input;
    }

    public static DateTime NullOrOutOfSQLDateRange(this IGuardClause guardClause,
         [NotNull][ValidatedNotNull] DateTime? input,
         [CallerArgumentExpression("input")] string parameterName = null,
         string? message = null)
    {
        guardClause.Null(input, nameof(input));
        return OutOfSQLDateRange(guardClause, input.Value, parameterName, message);
    }

    public static DateTime OutOfSQLDateRange(this IGuardClause guardClause,
        DateTime input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        // System.Data is unavailable in .NET Standard so we can't use SqlDateTime.
        const long sqlMinDateTicks = 552877920000000000;
        const long sqlMaxDateTicks = 3155378975999970000;

        return NullOrOutOfRangeInternal<DateTime>(guardClause, input, parameterName, new DateTime(sqlMinDateTicks), new DateTime(sqlMaxDateTicks), message);
    }

    public static T OutOfRange<T>(this IGuardClause guardClause,
        T input,
        string parameterName,
        [NotNull][ValidatedNotNull] T rangeFrom,
        [NotNull][ValidatedNotNull] T rangeTo,
        string? message = null) where T : IComparable, IComparable<T>
    {
        return NullOrOutOfRangeInternal<T>(guardClause, input, parameterName, rangeFrom, rangeTo, message);
    }

    public static T NullOrOutOfRange<T>(this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] T? input,
        string parameterName,
        [NotNull][ValidatedNotNull] T rangeFrom,
        [NotNull][ValidatedNotNull] T rangeTo,
        string? message = null) where T : IComparable<T>
    {
        guardClause.Null(input, nameof(input));
        return NullOrOutOfRangeInternal(guardClause, input, parameterName, rangeFrom, rangeTo, message);
    }

    public static T NullOrOutOfRange<T>(this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] T? input,
        string parameterName,
        [NotNull][ValidatedNotNull] T rangeFrom,
        [NotNull][ValidatedNotNull] T rangeTo,
        string? message = null) where T : struct, IComparable<T>
    {
        guardClause.Null(input, nameof(input));
        return NullOrOutOfRangeInternal<T>(guardClause, input.Value, parameterName, rangeFrom, rangeTo, message);
    }

    private static T NullOrOutOfRangeInternal<T>(this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] T? input,
        string? parameterName,
        [NotNull][ValidatedNotNull] T? rangeFrom,
        [NotNull][ValidatedNotNull] T? rangeTo,
        string? message = null) where T : IComparable<T>?
    {
        Guard.Against.Null(input, nameof(input));
        Guard.Against.Null(parameterName, nameof(parameterName));
        Guard.Against.Null(rangeFrom, nameof(rangeFrom));
        Guard.Against.Null(rangeTo, nameof(rangeTo));

        if (rangeFrom.CompareTo(rangeTo) > 0)
        {
            throw new ArgumentException(message ?? $"{nameof(rangeFrom)} should be less or equal than {nameof(rangeTo)}", parameterName);
        }

        if (input.CompareTo(rangeFrom) < 0 || input.CompareTo(rangeTo) > 0)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentOutOfRangeException(parameterName, $"Input {parameterName} was out of range");
            }
            throw new ArgumentOutOfRangeException(parameterName, message);
        }

        return input;
    }
}