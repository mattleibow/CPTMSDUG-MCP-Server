using Cptmsdug.Core.Models;
using System.Text.Json;
using System;

namespace Cptmsdug.Core.Tests;

public class EventJsonSerializationTests
{
    [Theory]
    [InlineData("13/09/2025 09:00", "13/09/2025 13:00")]
    [InlineData("17/09/2025 17:30", "17/09/2025 20:30")]
    [InlineData("22/10/2025 17:30", "22/10/2025 20:30")]
    public void Event_WithSastDateTimeFormat_SerializesAndDeserializesCorrectly(string startDateTime, string endDateTime)
    {
        // Arrange
        var json = $@"{{
            ""name"": ""Test Event"",
            ""startDateTime"": ""{startDateTime}"",
            ""endDateTime"": ""{endDateTime}"",
            ""venue"": ""Test Venue"",
            ""attendees"": 50,
            ""status"": ""Open""
        }}";

        // Act - Deserialize
        var eventItem = JsonSerializer.Deserialize<Event>(json);

        // Assert - Verify deserialization
        Assert.NotNull(eventItem);
        Assert.NotNull(eventItem.StartDateTime);
        Assert.NotNull(eventItem.EndDateTime);
        
        // Verify values
        var expectedStart = ParseSastDateTime(startDateTime);
        var expectedEnd = ParseSastDateTime(endDateTime);
        Assert.Equal(expectedStart, eventItem.StartDateTime);
        Assert.Equal(expectedEnd, eventItem.EndDateTime);
        Assert.Equal(expectedStart, eventItem.StartTime);
        Assert.Equal(expectedEnd, eventItem.EndTime);
        
        // Verify timezone
        Assert.Equal(TimeSpan.FromHours(2), eventItem.StartDateTime.Value.Offset);
        Assert.Equal(TimeSpan.FromHours(2), eventItem.EndDateTime.Value.Offset);

        // Act - Serialize back
        var serializedJson = JsonSerializer.Serialize(eventItem);
        
        // Assert - Should contain the original datetime strings
        Assert.Contains($"\"{startDateTime}\"", serializedJson);
        Assert.Contains($"\"{endDateTime}\"", serializedJson);
    }

    [Fact]
    public void Event_WithNullDateTimes_SerializesAndDeserializesCorrectly()
    {
        // Arrange
        var json = @"{
            ""name"": ""Test Event"",
            ""startDateTime"": null,
            ""endDateTime"": null,
            ""venue"": ""Test Venue"",
            ""attendees"": 50,
            ""status"": ""Open""
        }";

        // Act - Deserialize
        var eventItem = JsonSerializer.Deserialize<Event>(json);

        // Assert
        Assert.NotNull(eventItem);
        Assert.Null(eventItem.StartDateTime);
        Assert.Null(eventItem.EndDateTime);
        Assert.Null(eventItem.StartTime);
        Assert.Null(eventItem.EndTime);

        // Act - Serialize back
        var serializedJson = JsonSerializer.Serialize(eventItem);
        
        // Assert - Should contain null values
        Assert.Contains("\"startDateTime\":null", serializedJson);
        Assert.Contains("\"endDateTime\":null", serializedJson);
    }

    private static DateTimeOffset ParseSastDateTime(string dateTimeString)
    {
        var parsedDateTime = DateTime.ParseExact(dateTimeString, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        return new DateTimeOffset(parsedDateTime, TimeSpan.FromHours(2));
    }
}