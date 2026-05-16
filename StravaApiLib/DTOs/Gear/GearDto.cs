using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Gear
{
    public class GearDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        [JsonPropertyName("brand_name")]
        public string BrandName { get; set; }

        [JsonPropertyName("model_name")]
        public string ModelName { get; set; }

        [JsonPropertyName("frame_type")]
        public int? FrameType { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
