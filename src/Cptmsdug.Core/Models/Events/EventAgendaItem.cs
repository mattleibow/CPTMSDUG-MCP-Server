using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class EventAgendaItem
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("activity")]
    public string Activity { get; set; }
}

