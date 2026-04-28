using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class KudoserDto
    {
        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("show_name")]
        public bool ShowName { get; set; }
    }
}