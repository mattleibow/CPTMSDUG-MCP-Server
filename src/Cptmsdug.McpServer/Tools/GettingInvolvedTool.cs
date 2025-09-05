using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class GettingInvolvedTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about volunteering opportunities with CPTMSDUG. Perfect for answering 'How can I help organize events?', 'How can I volunteer?', and 'What volunteer roles are available?'")]
    public async Task<object> GetVolunteerOpportunities()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            VolunteerRoles = data.Opportunities.Volunteering.Roles,
            Benefits = new
            {
                CommunityImpact = $"Help serve {data.CommunityStats.Members}+ community members",
                PersonalGrowth = "Gain leadership and organizational experience",
                Networking = "Connect with fellow volunteers and community leaders",
                Recognition = "Be recognized as a community contributor"
            },
            ContactInformation = new
            {
                Email = data.Opportunities.Volunteering.Contact,
                Purpose = "Express interest in volunteering and discuss available opportunities"
            },
            CommunityImpact = new
            {
                Members = data.CommunityStats.Members,
                EventsHosted = data.CommunityStats.EventsHosted,
                YearsActive = data.Organization.YearsActive,
                CommunityMission = data.Mission.Primary
            },
            HowToStart = new
            {
                Step1 = "Attend a few events to get familiar with the community",
                Step2 = $"Contact us at {data.Opportunities.Volunteering.Contact}",
                Step3 = "Discuss available roles and your interests",
                Step4 = "Start with a role that matches your availability"
            }
        };
    }

    [McpServerTool]
    [Description("Get comprehensive information about speaking at CPTMSDUG events. Perfect for answering 'How can I speak at an event?', 'How do I submit a talk?', 'What topics are welcome?', and 'What are the benefits of speaking?'")]
    public async Task<object> GetSpeakingOpportunities()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            CallForSpeakers = new
            {
                Status = data.SpeakingOpportunities.CallForSpeakers
                    ? "OPEN - We're actively looking for speakers!"
                    : "Check back soon",
                SubmissionProcess = new
                {
                    Platform = "Sessionize.com",
                    SubmissionUrl = data.SpeakingOpportunities.SessionizeUrl,
                    ContactEmail = data.SpeakingOpportunities.ContactEmail,
                    ExperienceLevels = data.SpeakingOpportunities.ExperienceLevels
                }
            },
            WelcomedTopics = data.SpeakingOpportunities.WelcomedTopics,
            SpeakerBenefits = data.SpeakingOpportunities.SpeakerBenefits,
            CommunityReach = new
            {
                OnlineMembers = $"{data.CommunityStats.Members}+ community members",
                TotalSpeakers = data.SpeakerStatistics.TotalSpeakers,
                MicrosoftMVPs = data.SpeakerStatistics.MicrosoftMVPs,
                MicrosoftEmployees = data.SpeakerStatistics.MicrosoftEmployees,
                CommunityRating = data.CommunityStats.Rating
            },
            SpeakingTips = new
            {
                PreferredTopics = data.Technologies.Primary,
                SessionLength = "Typically 45-60 minutes including Q&A",
                Audience = "Mix of junior to senior developers",
                Support = "Organizers provide mentoring and feedback"
            },
            ContactEmail = data.SpeakingOpportunities.ContactEmail
        };
    }

    [McpServerTool]
    [Description("Get information about submitting session proposals and the speaker selection process. Use when someone needs specific details about how to apply to speak.")]
    public async Task<object> GetSessionSubmissionProcess()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            SubmissionPlatform = new
            {
                Name = "Sessionize.com",
                Url = data.SpeakingOpportunities.SessionizeUrl,
                Benefits = "Professional speaker profile management and easy submission process"
            },
            SubmissionRequirements = new
            {
                SessionTitle = "Clear and descriptive",
                Abstract = "Detailed description of what attendees will learn",
                Biography = "Speaker background and experience",
                SessionLevel = data.SpeakingOpportunities.ExperienceLevels
            },
            ContactInformation = new
            {
                Email = data.SpeakingOpportunities.ContactEmail,
                Purpose = "Questions about speaking opportunities or submission process"
            },
            PreferredTopics = data.SpeakingOpportunities.WelcomedTopics
        };
    }
}