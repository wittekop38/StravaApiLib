using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs
{
    public class SegmentDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("activity_type")]
        public string ActivityType { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("average_grade")]
        public double AverageGrade { get; set; }

        [JsonPropertyName("maximum_grade")]
        public double MaximumGrade { get; set; }

        [JsonPropertyName("elevation_high")]
        public double ElevationHigh { get; set; }

        [JsonPropertyName("elevation_low")]
        public double ElevationLow { get; set; }

        [JsonPropertyName("start_latlng")]
        public double[] StartLatlng { get; set; }

        [JsonPropertyName("end_latlng")]
        public double[] EndLatlng { get; set; }

        [JsonPropertyName("climb_category")]
        public int ClimbCategory { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("private")]
        public bool Private { get; set; }

        [JsonPropertyName("hazardous")]
        public bool Hazardous { get; set; }

        [JsonPropertyName("starred")]
        public bool Starred { get; set; }
    }
}
