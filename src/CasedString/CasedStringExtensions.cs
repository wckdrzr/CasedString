using System.Diagnostics.CodeAnalysis;

namespace WCKDRZR
{
    public static class CasedStringExtensions
    {
        public static bool NullableEquals([NotNullWhen(true)] this CasedString? casedString, [NotNullWhen(true)] CasedString? other)
        {
            if (casedString is null)
            {
                return other is null || other.Value is null;
            }
            return casedString.Equals(other);
        }

        public static bool NotEqual([NotNullWhen(true)] this CasedString? casedString, [NotNullWhen(true)] CasedString? other)
        {
            return !casedString.NullableEquals(other);
        }

        public static bool NullableEquals([NotNullWhen(true)] this string? s, [NotNullWhen(true)] CasedString? casedString)
        {
            if (casedString is null)
            {
                return s is null;
            }
            return casedString.Equals(s);
        }

        public static bool NotEqual([NotNullWhen(true)] this string? s, [NotNullWhen(true)] CasedString? casedString)
        {
            return !s.NullableEquals(casedString);
        }
    }
}
