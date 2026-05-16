using StravaApiLib.DTOs.Athletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class WaypointDto
    {
        [JsonPropertyName("latlng")]
        public double[] LatLng { get; set; }

        [JsonPropertyName("target_latlng")]
        public double[] TargetLatLng { get; set; }

        [JsonPropertyName("categories")]
        public string Categories { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("distance_into_route")]
        public float DistanceIntoRoute { get; set; }
    }
}
