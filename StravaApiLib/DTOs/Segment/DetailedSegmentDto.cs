using StravaApiLib.DTOs;
using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Segment
{
    public class DetailedSegmentDto : SummarySegmentDto
    {
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("total_elevation_gain")]
        public double TotalElevationGain { get; set; }

        [JsonPropertyName("map")]
        public MapDto? Map { get; set; }

        [JsonPropertyName("effort_count")]
        public int EffortCount { get; set; }

        [JsonPropertyName("athlete_count")]
        public int AthleteCount { get; set; }

        [JsonPropertyName("hazardous")]
        public bool Hazardous { get; set; }

        [JsonPropertyName("star_count")]
        public int StarCount { get; set; }

        [JsonPropertyName("starred")]
        public bool Starred { get; set; }
    }
}
