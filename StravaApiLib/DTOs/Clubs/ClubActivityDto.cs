using StravaApiLib.DTOs.Athletes;
using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Clubs
{
    public class ClubActivityDto
    {
        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        [JsonPropertyName("athlete")]
        public MetaAthleteDto? Athlete { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonPropertyName("total_elevation_gain")]
        public double TotalElevationGain { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("sport_type")]
        public string? SportType { get; set; }

        [JsonPropertyName("workout_type")]
        public int? WorkoutType { get; set; }
    }
}
