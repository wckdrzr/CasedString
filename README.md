# CasedString

CasedString is a string-like object with a CaseSensitive flag.  Toggle the flag and get the expected behaviour when comparing to other strings.

## Install

CasedString is available on NuGet.

To install, search "WckdRzr.CasedString" in your NuGet package manager, or visit the NuGet page: <https://www.nuget.org/packages/WckdRzr.CasedString/>

## Usage

CasedString can in most cases be used like a normal string, and unless otherwise specifed, the string will be case-insensitive.

```csharp
using WCKDRZR;

CasedString my_string = "Hello World";
my_string == "Hello World" // true
my_string == "hello world" // true
```

To make your string case-sensitive, set the flag:

```csharp
my_string.CaseSensitive = true;
my_string == "Hello World" // true
my_string == "hello world" // false
```

You can create a case-sensitive string in one line using the constructor:

```csharp
CasedString casedString = new("Hello World", true);
```

## Comparing CasedString

You can use `==` or `!=` to compare your CasedString object to strings and other CasedStrings

If either side of the comparision has `CaseSensitive` set to `true`, CasedString behaves like a normal string comparision, providing a case-sensitive match.  If neither side is case sensitive, a case-insensitive match is returned.

By default, case-insensitive matches use `StringComparison.OrdinalIgnoreCase`, you can use an alternative comparision by setting the `ComparisonType` property, or via the constructor: 

```csharp
```csharp
CasedString casedString = new("Hello World", comparisonType: StringComparison.InvariantCultureIgnoreCase);
```

Case-sensitive matches use `StringComparison.Ordinal` by default.  This can also be changed by setting the CaseSensitiveComparisonType property, or in the constructor.

## NULLs

CasedString objects can be declared null (as any other object), but they can also be declared with a null value:

```csharp
CasedString casedString = new(null);
```

In this state, `casedString == null` will be true, however the object properties can be set ready for when the value is set.

This is a conscious decision to allow easier serialisation and null declarations with CaseSensitve pre-set.

## Comparision Methods

Comparison is safest and most reliable using `==` and `!=`.  These operators handle null values better and do not care if either side is a String or a CasedString.  However the following are provided should you want them.

*please note, `string.Equals()` will always hit the built in string class, if you are comparing to a CasedString, make sure the CasedString object is on the left*

### Equals

Compare a CasedString to a `String` or `CasedString` object.  If you provide any other object type, the result will be false.  If `obj` is null, this method will return true if the CasedString value is also null.

```csharp
bool CasedString.Equals(object? obj)
```

### NotEqual

This is provided as an easy to read alternative to `!casedString.Equals(obj)`.  Unlike `Equals` it can be called agaist a null object.  It can be called agaist a string or a CasedString object and with either string or CasedString parameter.

```csharp
bool CasedString?.NotEqual(CasedString? casedString)
bool CasedString?.NotEqual(string? casedString)
bool string?.NotEqual(CasedString? casedString)
bool string?.NotEqual(string? casedString)
```

### NullableEquals

Unlike `Equals`, NullableEquals can be called agaist a null object. It can be called agaist a string or a CasedString object and with either string or CasedString parameter.

```csharp
bool CasedString?.NotEqual(CasedString? casedString)
bool CasedString?.NotEqual(string? casedString)
bool string?.NotEqual(CasedString? casedString)
bool string?.NotEqual(string? casedString)
```

## Concatenation

You can concatenate CasedStrings with `+` the same as usual strings, and concatenate them with strings.  If the left side of the operator has CaseSensitive set to true, the resulting object will have CaseSensitive set to true.

```csharp
CasedString casedString = new("Hello", caseSensitive: true);
casedString += " World";
casedString == "Hello World" //true
casedString == "hello world" //false
```

## Other Methods

### ToString

You can call ToString to get the value of the CasedString, although it is usually unnecessary, as CasedString has implicit string casting.

### GetHashCode

Returns the hash code of the orginal value.  Case sensitivity isn't considered.

## JSON

### Deserialisation

CasedString will deserialise to and from both strings and complex objects containing the CaseSensitive flag.  You can use `System.Text.Json` or `Newtonsoft.Json`.

```json
{
    "casedString": "Hello World"
}
```

```json
{
    "casedString": {
        "value": "Hello World",
        "caseSensitive": true
    }
}
```

### Serialisation

When serialising to a JSON string, if the CaseSensitive flag is set to the default false, it will be serialised as a simple string (like the first json example above).  If the flag is true, it will be serialised to a complex object (like the json second example above).
