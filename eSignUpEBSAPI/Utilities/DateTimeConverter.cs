using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eSignUpEBSAPI.Utilities
{
    //Not currently using this
    public class DateTimeConverter : JsonConverter<DateTime?>
    {
        private static readonly string[] AcceptedFormats = new[]
        {
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd HH:mm:ss.fff",
            "yyyy-MM-dd'T'HH:mm:ss",
            "yyyy-MM-dd'T'HH:mm:ss.fff",
            "yyyy-MM-dd"
        };

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException($"Unexpected token parsing date. TokenType: {reader.TokenType}");

            var s = reader.GetString();
            if (string.IsNullOrWhiteSpace(s))
                return null;

            if (DateTime.TryParseExact(s, AcceptedFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                return dt;

            // Fallback to liberal parse
            if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out dt))
                return dt;

            throw new JsonException($"Unable to parse DateTime: \"{s}\"");
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            // write with space format to match source, or use ISO: value.Value.ToString("o")
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        }
    }
}