using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class LapDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("activity")]
        public MetaActivityDto Activity { get; set; }

        [JsonPropertyName("athlete")]
        public MetaAthleteDto Athlete { get; set; }

        [JsonPropertyName("average_cadence")]
        public float AverageCadance { get; set; }

        [JsonPropertyName("average_speed")]
        public double AverageSpeed { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }

        [JsonPropertyName("end_index")]
        public int EndIndex { get; set; }

        [JsonPropertyName("lap_index")]
        public int LapIndex { get; set; }

        [JsonPropertyName("max_speed")]
        public double MaxSpeed { get; set; }

        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("pace_zone")]
        public int PaceZone { get; set; }

        [JsonPropertyName("split")]
        public int Split { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("start_date_local")]
        public DateTime StartDateLocal { get; set; }

        [JsonPropertyName("total_elevation_gain")]
        public double TotalElevationGain { get; set; }
    }
}
