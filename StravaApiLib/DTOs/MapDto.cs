using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class MapDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("summary_polyline")]
        public string SummaryPolyline { get; set; }

        [JsonPropertyName("polyline")]
        public string Polyline { get; set; }

        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }
    }
}
