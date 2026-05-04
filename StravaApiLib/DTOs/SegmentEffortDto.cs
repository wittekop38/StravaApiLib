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

        [JsonPropertyName("activity_id")]
        public long ActivityId { get; set; }

        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("start_date_local")]
        public DateTime StartDateLocal { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("is_kom")]
        public bool IsKom { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("activity")]
        public MetaActivityDto Activity { get; set; }

        [JsonPropertyName("athlete")]
        public MetaAthleteDto Athlete { get; set; }

        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }

        [JsonPropertyName("end_index")]
        public int EndIndex { get; set; }

        [JsonPropertyName("average_cadence")]
        public float AverageCadence { get; set; }

        [JsonPropertyName("average_watts")]
        public float? AverageWatts { get; set; }

        [JsonPropertyName("device_watts")]
        public bool DeviceWatts { get; set; }

        [JsonPropertyName("average_heartrate")]
        public float? AverageHeartrate { get; set; }

        [JsonPropertyName("max_heartrate")]
        public float? MaxHeartrate { get; set; }

        [JsonPropertyName("segment")]
        public SummarySegment Segment { get; set; }

        [JsonPropertyName("kom_rank")]
        public int? KomRank { get; set; }

        [JsonPropertyName("pr_rank")]
        public int? PrRank { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }
    }
}
