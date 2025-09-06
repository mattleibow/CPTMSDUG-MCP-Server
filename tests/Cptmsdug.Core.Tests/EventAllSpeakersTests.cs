using Cptmsdug.Core.Models;

namespace Cptmsdug.Core.Tests;

public class EventAllSpeakersTests
{
    [Fact]
    public void AllSpeakers_WithOnlySpeakersCollection_ReturnsAllSpeakers()
    {
        // Arrange - Based on "VS Code Dev Days - Cape Town" real data
        var event1 = new Event
        {
            Speakers = new List<Speaker>
            {
                new Speaker 
                { 
                    Name = "Nicolas Blank", 
                    Title = "Founder & CEO | Microsoft MVP",
                    Company = "Independent",
                    Specialties = new List<string> { "Microsoft Infrastructure", "Security", "Migration" },
                    Mvp = true
                },
                new Speaker 
                { 
                    Name = "Matthew Levy", 
                    Title = "Solutions Architect at Threatscape",
                    Company = "Threatscape",
                    Specialties = new List<string> { "Identity Governance", "Security Architecture" }
                },
                new Speaker 
                { 
                    Name = "Matthew Leibowitz", 
                    Title = "Principal Software Engineer at Microsoft",
                    Company = "Microsoft",
                    Specialties = new List<string> { ".NET MAUI", "Cross-Platform", "SkiaSharp" }
                },
                new Speaker 
                { 
                    Name = "Allan Pead", 
                    Title = "Microsoft Developer Technologies MVP, Microsoft Internet of Things MVP, Xamarin MVP",
                    Company = "Independent",
                    Specialties = new List<string> { "Developer Technologies", "IoT", "Xamarin", "Architecture" }
                }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Equal(4, allSpeakers.Count);
        Assert.Contains(allSpeakers, s => s.Name == "Nicolas Blank" && s.Company == "Independent");
        Assert.Contains(allSpeakers, s => s.Name == "Matthew Levy" && s.Company == "Threatscape");
        Assert.Contains(allSpeakers, s => s.Name == "Matthew Leibowitz" && s.Company == "Microsoft");
        Assert.Contains(allSpeakers, s => s.Name == "Allan Pead" && s.Company == "Independent");
    }

    [Fact]
    public void AllSpeakers_WithOnlySessionSpeakers_ReturnsSessionSpeakers()
    {
        // Arrange - Based on "RAG + Building a WordPress Site From Scratch" real data
        var event1 = new Event
        {
            Sessions = new List<EventSession>
            {
                new EventSession 
                { 
                    Speaker = "Abed Matini - Senior Backend Developer at Ogilvy South Africa | AI Developer", 
                    Title = "Bring Your Data to AI: A Practical Guide to Retrieval‑Augmented Generation (RAG)" 
                },
                new EventSession 
                { 
                    Speaker = "Louise van der Bijl - Web Specialist, Account & Client Administration", 
                    Title = "60 Minutes to Glory: Building a WordPress Site From Scratch Without Crying (Much)" 
                }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Equal(2, allSpeakers.Count);
        Assert.Contains(allSpeakers, s => s.Name == "Abed Matini - Senior Backend Developer at Ogilvy South Africa | AI Developer");
        Assert.Contains(allSpeakers, s => s.Name == "Louise van der Bijl - Web Specialist, Account & Client Administration");
        
        // Verify that these are basic Speaker objects (only name populated)
        var firstSpeaker = allSpeakers.First(s => s.Name.Contains("Abed Matini"));
        Assert.Null(firstSpeaker.Company);
        Assert.Null(firstSpeaker.Title);
    }

    [Fact]
    public void AllSpeakers_WithOnlyDirectSpeaker_ReturnsDirectSpeaker()
    {
        // Arrange - Based on "Special Event with Richard Campbell" real data
        var event1 = new Event
        {
            Speaker = "Richard Campbell (.NET Rocks, RunAs Radio)"
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Single(allSpeakers);
        Assert.Equal("Richard Campbell (.NET Rocks, RunAs Radio)", allSpeakers.First().Name);
        
        // Verify it's a basic Speaker object
        Assert.Null(allSpeakers.First().Company);
        Assert.Null(allSpeakers.First().Title);
    }

    [Fact]
    public void AllSpeakers_WithRealSessionSpeakerVariations_HandlesAllFormats()
    {
        // Arrange - Based on actual session speaker name formats from real data
        var event1 = new Event
        {
            Sessions = new List<EventSession>
            {
                // Format 1: "Name - Title at Company | Role"
                new EventSession { Speaker = "Abed Matini - Senior Backend Developer at Ogilvy South Africa | AI Developer" },
                // Format 2: "Name, Title at Company"
                new EventSession { Speaker = "Matthew Leibowitz, Principal Software Engineer at Microsoft" },
                // Format 3: "Name - Role at Company"
                new EventSession { Speaker = "Neil Thompson - Managing Consultant at Accso" },
                // Format 4: "Name - Title, Role"
                new EventSession { Speaker = "Louise van der Bijl - Web Specialist, Account & Client Administration" }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Equal(4, allSpeakers.Count);
        Assert.Contains(allSpeakers, s => s.Name == "Abed Matini - Senior Backend Developer at Ogilvy South Africa | AI Developer");
        Assert.Contains(allSpeakers, s => s.Name == "Matthew Leibowitz, Principal Software Engineer at Microsoft");
        Assert.Contains(allSpeakers, s => s.Name == "Neil Thompson - Managing Consultant at Accso");
        Assert.Contains(allSpeakers, s => s.Name == "Louise van der Bijl - Web Specialist, Account & Client Administration");
    }

    [Fact]
    public void AllSpeakers_WithMixedSources_MergesAllWithoutDuplicates()
    {
        // Arrange - Simulating potential real-world scenario where same speaker appears in different formats
        var event1 = new Event
        {
            Speaker = "Matthew Leibowitz (Microsoft)", // Direct speaker with simplified format
            Speakers = new List<Speaker>
            {
                new Speaker 
                { 
                    Name = "Matthew Leibowitz", 
                    Title = "Principal Software Engineer",
                    Company = "Microsoft" 
                },
                new Speaker 
                { 
                    Name = "Allan Pead", 
                    Title = "Microsoft MVP",
                    Company = "Independent" 
                }
            },
            Sessions = new List<EventSession>
            {
                new EventSession { Speaker = "Matthew Leibowitz, Principal Software Engineer at Microsoft" }, // Same person, different format
                new EventSession { Speaker = "Nicolas Blank - Microsoft MVP" }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        // Should have 5 speakers total (detailed speakers are preserved, session speakers are added separately)
        // Note: Different string formats are treated as separate speakers since exact matching is used
        Assert.Equal(5, allSpeakers.Count);
        
        // Detailed speakers should be preserved with their full information
        Assert.Contains(allSpeakers, s => s.Name == "Matthew Leibowitz" && s.Company == "Microsoft");
        Assert.Contains(allSpeakers, s => s.Name == "Allan Pead" && s.Company == "Independent");
        
        // Session speakers as separate entries (different format = different speaker object)
        Assert.Contains(allSpeakers, s => s.Name == "Matthew Leibowitz, Principal Software Engineer at Microsoft");
        Assert.Contains(allSpeakers, s => s.Name == "Nicolas Blank - Microsoft MVP");
        
        // Direct speaker as separate entry
        Assert.Contains(allSpeakers, s => s.Name == "Matthew Leibowitz (Microsoft)");
    }

    [Fact]
    public void AllSpeakers_WithEmptySources_ReturnsEmptyList()
    {
        // Arrange - Based on events like "CPTMSDUG - Games Night" which have no speakers
        var event1 = new Event();

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Empty(allSpeakers);
    }

    [Fact]
    public void AllSpeakers_WithEmptyStringSpeakers_IgnoresEmptyStrings()
    {
        // Arrange
        var event1 = new Event
        {
            Speaker = "", // Should be ignored
            Sessions = new List<EventSession>
            {
                new EventSession { Speaker = "", Title = "Session 1" }, // Should be ignored
                new EventSession { Speaker = "Valid Speaker", Title = "Session 2" }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Single(allSpeakers);
        Assert.Equal("Valid Speaker", allSpeakers.First().Name);
    }

    [Fact]
    public void AllSpeakers_CaseInsensitiveDeduplication_WorksCorrectly()
    {
        // Arrange
        var event1 = new Event
        {
            Speaker = "richard campbell",
            Speakers = new List<Speaker>
            {
                new Speaker { Name = "Richard Campbell", Title = ".NET Rocks Host" }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Single(allSpeakers); // Should be deduplicated despite case difference
        Assert.Equal("Richard Campbell", allSpeakers.First().Name); // Detailed version should be kept
        Assert.Equal(".NET Rocks Host", allSpeakers.First().Title);
    }

    [Fact]
    public void AllSpeakers_WithSessionsButNoSpeakers_HandlesCorrectly()
    {
        // Arrange - Sessions exist but some have empty speaker property
        var event1 = new Event
        {
            Sessions = new List<EventSession>
            {
                new EventSession { Title = "Session without speaker" },
                new EventSession { Speaker = "", Title = "Session with empty speaker" },
                new EventSession { Speaker = "Valid Speaker", Title = "Session with speaker" }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Single(allSpeakers);
        Assert.Equal("Valid Speaker", allSpeakers.First().Name);
    }

    [Fact]
    public void AllSpeakers_PreservesDetailedSpeakerInformation()
    {
        // Arrange - Ensure detailed speaker properties are maintained
        var event1 = new Event
        {
            Speakers = new List<Speaker>
            {
                new Speaker 
                { 
                    Name = "Test Speaker",
                    Title = "Senior Developer",
                    Company = "Test Company",
                    Description = "Test Description",
                    Specialties = new List<string> { "C#", ".NET" },
                    Mvp = true,
                    Experience = "5+ years",
                    Tags = new List<string> { "MVP", "Speaker" },
                    Events = new List<string> { "Event 1" },
                    Achievements = new List<string> { "Achievement 1" }
                }
            }
        };

        // Act
        var allSpeakers = event1.AllSpeakers;

        // Assert
        Assert.Single(allSpeakers);
        var speaker = allSpeakers.First();
        Assert.Equal("Test Speaker", speaker.Name);
        Assert.Equal("Senior Developer", speaker.Title);
        Assert.Equal("Test Company", speaker.Company);
        Assert.Equal("Test Description", speaker.Description);
        Assert.Equal(2, speaker.Specialties?.Count);
        Assert.True(speaker.Mvp);
        Assert.Equal("5+ years", speaker.Experience);
    }
}