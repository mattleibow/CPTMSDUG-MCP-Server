using System.Text.Json;
using System.Text.Json.Serialization;
using Cptmsdug.Core.Models;

namespace Cptmsdug.Core.Converters;

public class EventSessionConverter : JsonConverter<EventSession>
{
    public override EventSession? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            // Handle string sessions (just the title)
            var title = reader.GetString();
            return new EventSession
            {
                Title = title ?? string.Empty,
                Time = string.Empty,
                Speaker = string.Empty,
                Abstract = string.Empty,
                LearningOutcomes = new List<string>(),
                FunFact = string.Empty,
                Note = string.Empty
            };
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            // Handle object sessions (full EventSession structure)
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            return new EventSession
            {
                Time = root.TryGetProperty("time", out var timeProp) ? timeProp.GetString() ?? string.Empty : string.Empty,
                Title = root.TryGetProperty("title", out var titleProp) ? titleProp.GetString() ?? string.Empty : string.Empty,
                Speaker = root.TryGetProperty("speaker", out var speakerProp) ? speakerProp.GetString() ?? string.Empty : string.Empty,
                Abstract = root.TryGetProperty("abstract", out var abstractProp) ? abstractProp.GetString() ?? string.Empty : string.Empty,
                LearningOutcomes = root.TryGetProperty("learningOutcomes", out var learningProp) && learningProp.ValueKind == JsonValueKind.Array
                    ? learningProp.EnumerateArray().Select(x => x.GetString() ?? string.Empty).ToList()
                    : new List<string>(),
                FunFact = root.TryGetProperty("funFact", out var funFactProp) ? funFactProp.GetString() ?? string.Empty : string.Empty,
                Note = root.TryGetProperty("note", out var noteProp) ? noteProp.GetString() ?? string.Empty : string.Empty
            };
        }

        throw new JsonException($"Unable to convert {reader.TokenType} to EventSession");
    }

    public override void Write(Utf8JsonWriter writer, EventSession value, JsonSerializerOptions options)
    {
        // For writing, we'll always write the full object structure
        writer.WriteStartObject();

        writer.WriteString("time", value.Time);
        writer.WriteString("title", value.Title);
        writer.WriteString("speaker", value.Speaker);
        writer.WriteString("abstract", value.Abstract);

        writer.WriteStartArray("learningOutcomes");
        foreach (var outcome in value.LearningOutcomes ?? new List<string>())
        {
            writer.WriteStringValue(outcome);
        }
        writer.WriteEndArray();

        writer.WriteString("funFact", value.FunFact);
        writer.WriteString("note", value.Note);

        writer.WriteEndObject();
    }
}