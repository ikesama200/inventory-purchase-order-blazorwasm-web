using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryPurchaseOrderWeb.Converters
{
    public class DateTimeSpaceJsonConverter : JsonConverter<DateTime>
    {
        private readonly string[] _formats = { "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd" };

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? str = reader.GetString();
            if (str != null && DateTime.TryParseExact(str, _formats, CultureInfo.InvariantCulture,
                                                      DateTimeStyles.None, out var dt))
            {
                return dt;
            }
            throw new JsonException($"Cannot convert {str} to DateTime");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
