using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WCKDRZR
{
    [System.Text.Json.Serialization.JsonConverter(typeof(CasedStringConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(CasedStringConverterForNewtonsoft))]
    public class CasedString : IEquatable<CasedString>, IEqualityComparer<CasedString>
    {
        internal string? Value { get; set; }

        public bool CaseSensitive { get; set; } = false;
        public StringComparison ComparisonType { get; set; } = StringComparison.OrdinalIgnoreCase;
        public StringComparison CaseSensitiveComparisonType { get; set; } = StringComparison.Ordinal;

        public CasedString(string? value, bool caseSensitive = false,
            StringComparison comparisonType = StringComparison.OrdinalIgnoreCase,
            StringComparison caseSensitiveComparisonType = StringComparison.CurrentCulture
            )
        {
            Value = value;
            CaseSensitive = caseSensitive;
            ComparisonType = comparisonType;
            CaseSensitiveComparisonType = caseSensitiveComparisonType;
        }


        [return: NotNullIfNotNull("obj")]
        public static implicit operator String?(CasedString? obj)
        {
            return obj?.Value;
        }

        [return: NotNullIfNotNull("str")]
        public static implicit operator CasedString?(string? str)
        {
            return str == null ? null : new(str);
        }


        public static bool operator ==([NotNullWhen(true)] CasedString? a, [NotNullWhen(true)] CasedString? b)
        {
            return a is null ? b is null || b.Value is null : a.NullableEquals(b);
        }

        public static bool operator !=([NotNullWhen(false)] CasedString? a, [NotNullWhen(false)] CasedString? b)
        {
            return a is null ? b is not null && b.Value is not null : a.NotEqual(b);
        }

        public static CasedString operator +(CasedString? a, CasedString? b)
        {
            return new(a?.Value + b?.Value, a?.CaseSensitive ?? b?.CaseSensitive ?? false);
        }


        public override string? ToString()
        {
            return Value;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null)
            {
                return Value is null;
            }

            CasedString casedString;
            if (obj.GetType() == typeof(CasedString))
            {
                casedString = (CasedString)obj;
            }
            else if (obj.GetType() == typeof(string))
            {
                casedString = new((string)obj);
            }
            else
            {
                return false;
            }

            if (CaseSensitive || casedString.CaseSensitive)
            {
                return string.Equals(Value, casedString.Value, CaseSensitiveComparisonType);
            }
            else
            {
                return string.Equals(Value, casedString.Value, ComparisonType);
            }
        }

        bool IEquatable<CasedString>.Equals([NotNullWhen(true)] CasedString? other)
        {
            return Equals(other as CasedString);
        }

        public bool Equals(CasedString? x, CasedString? y)
        {
            return x.NullableEquals(y);
        }

        public override int GetHashCode()
        {
            return Value is null ? 0 : Value.GetHashCode();
        }

        public int GetHashCode([DisallowNull] CasedString obj)
        {
            return obj.Value is null ? 0 : obj.Value.GetHashCode();
        }
    }
}
