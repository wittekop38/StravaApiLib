using StravaApiLib.DTOs.Athletes;
using StravaApiLib.DTOs.Segment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs.Routes
{
    public class RouteDto
    {
        [JsonPropertyName("athlete")]
        public SummaryAthleteDto Athlete { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        [JsonPropertyName("elevation_gain")]
        public float ElevationGain { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("id_str")]
        public string IdStr { get; set; }

        [JsonPropertyName("map")]
        public MapDto Map { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("private")]
        public bool Private { get; set; }

        [JsonPropertyName("starred")]
        public bool Starred { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("sub_type")]
        public int SubType { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("estimated_moving_time")]
        public int EstimatedMovingTime { get; set; }

        [JsonPropertyName("segments")]
        public List<SummarySegmentDto> Segments { get; set; }

        [JsonPropertyName("waypoints")]
        public List<WaypointDto> Waypoints { get; set; }
    }
}
