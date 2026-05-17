using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Activities
{
    public class ActivityZoneDto
    {
        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("distribution_buckets")]
        public List<TimedZoneRangeDto> DistributionBuckets { get; set; } = [];

        /// <summary>"heartrate" or "power"</summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("sensor_based")]
        public bool SensorBased { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("custom_zones")]
        public bool CustomZones { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }
    }

    public class TimedZoneRangeDto
    {
        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        /// <summary>Seconds spent in this zone.</summary>
        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}
