using static System.Text.Json.JsonElement;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace WCKDRZR
{
    public class CasedStringConverter : JsonConverter<CasedString>
    {
        public override CasedString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out JsonDocument? jDoc))
            {
                CasedString? casedString = null;
                if (jDoc.RootElement.ValueKind == JsonValueKind.String)
                {
                    casedString = new(jDoc.RootElement.ToString());
                }
                else
                {
                    if (jDoc.RootElement.TryGetPropertyNoCase(nameof(CasedString.Value), out JsonElement value))
                    {
                        casedString = new(value.ValueKind == JsonValueKind.Null ? null : value.ToString());
                        if (jDoc.RootElement.TryGetPropertyNoCase(nameof(CasedString.CaseSensitive), out JsonElement caseSensitive))
                        {
                            casedString.CaseSensitive = caseSensitive.GetBoolean();
                        }
                    }
                }
                return casedString;
            }

            throw new ArgumentException("Cannot convert object to CasedString");
        }

        public override void Write(Utf8JsonWriter writer, CasedString value, JsonSerializerOptions options)
        {
            if (value == null && value?.CaseSensitive == false)
            {
                writer.WriteNullValue();
            }
            else if (value?.CaseSensitive == true)
            {
                writer.WriteStartObject();
                writer.WriteString(nameof(CasedString.Value), value.Value);
                writer.WriteBoolean(nameof(CasedString.CaseSensitive), value.CaseSensitive);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStringValue(value?.Value ?? "");
            }
        }
    }

    internal static class CasedStringConverterExtension
    {
        internal static bool TryGetPropertyNoCase(this JsonElement element, string propertyName, out JsonElement value)
        {
            ObjectEnumerator enumerator = element.EnumerateObject();
            JsonProperty property = enumerator.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
            value = property.Value;
            return property.Value.ValueKind != JsonValueKind.Undefined;
        }
    }
}
