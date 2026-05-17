using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Streams
{
    public class StreamDto<T>
    {
        /// <summary>"distance" or "time"</summary>
        [JsonPropertyName("series_type")]
        public string SeriesType { get; set; } = string.Empty;

        [JsonPropertyName("original_size")]
        public int OriginalSize { get; set; }

        /// <summary>"low", "medium", or "high"</summary>
        [JsonPropertyName("resolution")]
        public string Resolution { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public List<T> Data { get; set; } = [];
    }
}
