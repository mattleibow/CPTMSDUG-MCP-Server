using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Converters;

/// <summary>
/// Converts DateTimeOffset to/from SAST format: "dd/MM/yyyy HH:mm" with UTC+2 offset
/// </summary>
public class SastDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    private const string DateTimeFormat = "dd/MM/yyyy HH:mm";
    private static readonly TimeSpan SastOffset = TimeSpan.FromHours(2);

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            throw new JsonException("Cannot parse null or empty string as DateTimeOffset");
        }

        if (DateTime.TryParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDateTime))
        {
            return new DateTimeOffset(parsedDateTime, SastOffset);
        }

        throw new JsonException($"Cannot parse '{value}' as DateTimeOffset with format '{DateTimeFormat}'");
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        // Convert to SAST timezone and format as string
        var sastTime = value.ToOffset(SastOffset);
        var formattedValue = sastTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        writer.WriteStringValue(formattedValue);
    }
}