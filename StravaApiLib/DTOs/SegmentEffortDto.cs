using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class SegmentEffortDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("activity")]
        public MetaActivityDto Activity { get; set; }

        [JsonPropertyName("athlete")]
        public MetaAthleteDto Athlete { get; set; }

        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("start_date_local")]
        public DateTime StartDateLocal { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("segment")]
        public SegmentDto Segment { get; set; }

        [JsonPropertyName("kom_rank")]
        public int? KomRank { get; set; }

        [JsonPropertyName("pr_rank")]
        public int? PrRank { get; set; }

        [JsonPropertyName("achievements")]
        public List<AchievementDto> Achievements { get; set; }

        [JsonPropertyName("average_watts")]
        public double? AverageWatts { get; set; }

        [JsonPropertyName("device_watts")]
        public bool DeviceWatts { get; set; }
    }
}
