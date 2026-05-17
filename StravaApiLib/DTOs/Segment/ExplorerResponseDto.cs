using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Segment
{
    public class ExplorerResponseDto
    {
        [JsonPropertyName("segments")]
        public List<ExplorerSegmentDto> Segments { get; set; } = [];
    }

    public class ExplorerSegmentDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("climb_category")]
        public int ClimbCategory { get; set; }

        /// <summary>"NC", "4", "3", "2", "1", or "HC"</summary>
        [JsonPropertyName("climb_category_desc")]
        public string? ClimbCategoryDesc { get; set; }

        [JsonPropertyName("avg_grade")]
        public double AvgGrade { get; set; }

        [JsonPropertyName("start_latlng")]
        public double[]? StartLatlng { get; set; }

        [JsonPropertyName("end_latlng")]
        public double[]? EndLatlng { get; set; }

        [JsonPropertyName("elev_difference")]
        public double ElevDifference { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        /// <summary>Encoded polyline for the segment.</summary>
        [JsonPropertyName("points")]
        public string? Points { get; set; }

        [JsonPropertyName("starred")]
        public bool Starred { get; set; }
    }
}
