using StravaApiLib.DTOs.Athletes;
using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Activities
{
    public class CommentDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("activity_id")]
        public long ActivityId { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        [JsonPropertyName("athlete")]
        public SummaryAthleteDto? Athlete { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
