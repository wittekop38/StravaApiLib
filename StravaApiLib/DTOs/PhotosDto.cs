using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class PhotosDto
    {
        public PrimaryPhotoDto Primary { get; set; }
        public bool UsePrimaryPhoto { get; set; }
        public int Count { get; set; }
    }

    public class PrimaryPhotoDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("source")]
        public int? Source { get; set; }

        [JsonPropertyName("unique_id")]
        public string UniqueId { get; set; }

        [JsonPropertyName("urls")]
        public Dictionary<string, string> Urls { get; set; }
    }
}
