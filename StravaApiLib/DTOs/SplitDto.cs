using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class SplitDto
    {
        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        [JsonPropertyName("elevation_difference")]
        public double ElevationDifference { get; set; }

        [JsonPropertyName("average_speed")]
        public double AverageSpeed { get; set; }

        [JsonPropertyName("pace_zone")]
        public int PaceZone { get; set; }
    }
}
