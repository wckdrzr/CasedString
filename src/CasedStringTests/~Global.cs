global using Xunit;
global using FluentAssertions;

using WCKDRZR.CasedString;

public static class TestStrings
{
    public static string ProperCaseString = "Foo Bar";
    public static string LowerCaseString = "foo bar";
    public static string? NullableStringProper = "Foo Bar";
    public static string? NullString = null;
}

public static class TestObjects
{
    public static CasedString ObjectProper = new(TestStrings.ProperCaseString);
    public static CasedString ObjectLower = new(TestStrings.LowerCaseString);
    public static CasedString? ObjectNull = null;
    public static CasedString ObjectNullValue = new(null);
    public static CasedString? ObjectNullableNull = new(null);
    public static CasedString? ObjectNullableProper = new(TestStrings.ProperCaseString);
}