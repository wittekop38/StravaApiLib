using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs.Segment
{
    public class SummaryPRSegmentEffortDto
    {
        [JsonPropertyName("pr_activity_id")]
        public long PrActivityId { get; set; }

        [JsonPropertyName("pr_elapsed_time")]
        public int PrElapsedTime { get; set; }

        [JsonPropertyName("pr_date")]
        public DateTime PrDate { get; set; }

        [JsonPropertyName("effort_count")]
        public int EffortCount { get; set; }
    }
}
