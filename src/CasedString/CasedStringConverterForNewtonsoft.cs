using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace WCKDRZR
{
    public class CasedStringConverterForNewtonsoft : JsonConverter<CasedString>
    {
        public override CasedString? ReadJson(JsonReader reader, Type objectType, CasedString? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            CasedString? casedString = null;
            if (reader.ValueType == typeof(String))
            {
                casedString = new(reader.Value?.ToString());
            }
            else if (reader.TokenType != JsonToken.Null)
            {
                JObject jObject = JObject.Load(reader);
                if (jObject.TryGetValue(nameof(CasedString.Value), StringComparison.OrdinalIgnoreCase, out JToken? value))
                {
                    casedString = new(value.Type == JTokenType.Null ? null : value.ToString());
                    if (jObject.TryGetValue(nameof(CasedString.CaseSensitive), StringComparison.OrdinalIgnoreCase, out JToken? caseSensitive))
                    {
                        casedString.CaseSensitive = ((bool)caseSensitive);
                    }
                }
            }

            return casedString;
        }

        public override void WriteJson(JsonWriter writer, CasedString? value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value == null && value?.CaseSensitive == false)
            {
                writer.WriteNull();
            }
            else if (value?.CaseSensitive == true)
            {
                JObject jObj = new();
                jObj.Add(new JProperty(nameof(CasedString.Value), value.Value));
                jObj.Add(new JProperty(nameof(CasedString.CaseSensitive), value.CaseSensitive));
                jObj.WriteTo(writer);
            }
            else
            {
                writer.WriteValue(value?.Value ?? "");
            }
        }
    }
}
