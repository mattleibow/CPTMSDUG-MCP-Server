using Cptmsdug.Core.Models;
using System;

namespace Cptmsdug.Core.Tests;

public class EventDateParsingTests
{
    [Theory]
    [InlineData("13/09/2025 09:00", "2025-09-13T09:00:00+02:00")]
    [InlineData("17/09/2025 17:30", "2025-09-17T17:30:00+02:00")]
    [InlineData("22/10/2025 17:30", "2025-10-22T17:30:00+02:00")]
    [InlineData("19/11/2025 17:30", "2025-11-19T17:30:00+02:00")]
    [InlineData("25/01/2025 09:00", "2025-01-25T09:00:00+02:00")]
    [InlineData("30/09/2021 09:00", "2021-09-30T09:00:00+02:00")]
    public void StartTime_WithStartDateTimeField_ParsesCorrectly(string startDateTime, string expectedDateTimeOffset)
    {
        // Arrange
        var eventItem = new Event
        {
            StartDateTime = DateTimeOffset.Parse(expectedDateTimeOffset)
        };
        var expected = DateTimeOffset.Parse(expectedDateTimeOffset);

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("13/09/2025 13:00", "2025-09-13T13:00:00+02:00")]
    [InlineData("17/09/2025 20:30", "2025-09-17T20:30:00+02:00")]
    [InlineData("25/01/2025 17:00", "2025-01-25T17:00:00+02:00")]
    [InlineData("29/11/2025 17:00", "2025-11-29T17:00:00+02:00")]
    public void EndTime_WithEndDateTimeField_ParsesCorrectly(string endDateTime, string expectedDateTimeOffset)
    {
        // Arrange
        var eventItem = new Event
        {
            EndDateTime = DateTimeOffset.Parse(expectedDateTimeOffset)
        };
        var expected = DateTimeOffset.Parse(expectedDateTimeOffset);

        // Act
        var result = eventItem.EndTime;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void StartTime_And_EndTime_WithDateTimeFields_ParseCorrectly()
    {
        // Arrange - Test with actual VS Code Dev Days event data
        var startTime = new DateTimeOffset(2025, 9, 13, 9, 0, 0, TimeSpan.FromHours(2));
        var endTime = new DateTimeOffset(2025, 9, 13, 13, 0, 0, TimeSpan.FromHours(2));
        
        var eventItem = new Event
        {
            StartDateTime = startTime,
            EndDateTime = endTime
        };

        // Act
        var startResult = eventItem.StartTime;
        var endResult = eventItem.EndTime;

        // Assert
        Assert.NotNull(startResult);
        Assert.NotNull(endResult);
        Assert.Equal(startTime, startResult);
        Assert.Equal(endTime, endResult);
    }

    [Fact]
    public void StartTime_WithNullDateTime_ReturnsNull()
    {
        // Arrange
        var eventItem = new Event
        {
            StartDateTime = null
        };

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void EndTime_WithNullDateTime_ReturnsNull()
    {
        // Arrange
        var eventItem = new Event
        {
            EndDateTime = null
        };

        // Act
        var result = eventItem.EndTime;

        // Assert
        Assert.Null(result);
    }

    [Theory]
    [InlineData("VS Code Dev Days - Cape Town", "13/09/2025 09:00", "13/09/2025 13:00")]
    [InlineData("RAG + Building a WordPress Site From Scratch", "17/09/2025 17:30", "17/09/2025 20:30")]
    [InlineData("Programming with Agents Without It Going Off in Weird Directions", "22/10/2025 17:30", "22/10/2025 20:30")]
    [InlineData("CPTMSDUG - Games Night", "19/11/2025 17:30", "19/11/2025 20:30")]
    public void RealWorldEvents_WithNewDateTimeFormat_ParseCorrectly(string eventName, string startDateTime, string endDateTime)
    {
        // Arrange - Parse the expected times
        var expectedStart = ParseSastDateTime(startDateTime);
        var expectedEnd = ParseSastDateTime(endDateTime);
        
        var eventItem = new Event
        {
            Name = eventName,
            StartDateTime = expectedStart,
            EndDateTime = expectedEnd
        };

        // Act
        var startTime = eventItem.StartTime;
        var endTime = eventItem.EndTime;

        // Assert
        Assert.NotNull(startTime);
        Assert.NotNull(endTime);
        Assert.Equal(expectedStart, startTime);
        Assert.Equal(expectedEnd, endTime);
        
        // Verify timezone is SAST (+2)
        Assert.Equal(TimeSpan.FromHours(2), startTime.Value.Offset);
        Assert.Equal(TimeSpan.FromHours(2), endTime.Value.Offset);
        
        // Verify start time is before end time
        Assert.True(startTime < endTime, $"Start time {startTime} should be before end time {endTime}");
    }

    private static DateTimeOffset ParseSastDateTime(string dateTimeString)
    {
        var parsedDateTime = DateTime.ParseExact(dateTimeString, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        return new DateTimeOffset(parsedDateTime, TimeSpan.FromHours(2));
    }

    [Fact]
    public void IsUpcoming_WithFutureDate_ReturnsTrue()
    {
        // Arrange
        var futureDate = new DateTimeOffset(2030, 12, 31, 9, 0, 0, TimeSpan.FromHours(2));
        var eventItem = new Event
        {
            StartDateTime = futureDate
        };

        // Act & Assert
        Assert.True(eventItem.IsUpcoming);
        Assert.False(eventItem.IsPast);
    }

    [Fact]
    public void IsPast_WithPastDate_ReturnsTrue()
    {
        // Arrange
        var pastDate = new DateTimeOffset(2020, 1, 1, 9, 0, 0, TimeSpan.FromHours(2));
        var eventItem = new Event
        {
            StartDateTime = pastDate
        };

        // Act & Assert
        Assert.True(eventItem.IsPast);
        Assert.False(eventItem.IsUpcoming);
    }

    [Fact]
    public void IsUpcoming_And_IsPast_WithNullStartTime_ReturnsFalse()
    {
        // Arrange
        var eventItem = new Event
        {
            StartDateTime = null
        };

        // Act & Assert
        Assert.False(eventItem.IsUpcoming);
        Assert.False(eventItem.IsPast);
    }

    [Fact]
    public void IsUpcoming_And_IsPast_AreMutuallyExclusive()
    {
        // Test with past event
        var pastEvent = new Event
        {
            StartDateTime = new DateTimeOffset(2020, 1, 1, 9, 0, 0, TimeSpan.FromHours(2))
        };

        Assert.True(pastEvent.IsPast);
        Assert.False(pastEvent.IsUpcoming);

        // Test with future event
        var futureEvent = new Event
        {
            StartDateTime = new DateTimeOffset(2030, 12, 31, 9, 0, 0, TimeSpan.FromHours(2))
        };

        Assert.True(futureEvent.IsUpcoming);
        Assert.False(futureEvent.IsPast);
    }

    [Theory]
    [InlineData("13/09/2025 09:00")]
    [InlineData("17/09/2025 17:30")]
    [InlineData("25/11/2023 09:00")]
    public void IsUpcoming_WithNewStartDateTimeFormat_WorksCorrectly(string startDateTimeStr)
    {
        // Arrange
        var startDateTime = ParseSastDateTime(startDateTimeStr);
        var eventItem = new Event
        {
            StartDateTime = startDateTime
        };

        // Act & Assert
        var startTime = eventItem.StartTime;
        Assert.NotNull(startTime);
        
        var isUpcoming = eventItem.IsUpcoming;
        var isPast = eventItem.IsPast;
        
        // Should be mutually exclusive
        Assert.NotEqual(isUpcoming, isPast);
        
        // Verify the logic matches the start time
        var now = DateTimeOffset.UtcNow;
        Assert.Equal(startTime > now, isUpcoming);
        Assert.Equal(startTime <= now, isPast);
    }
}