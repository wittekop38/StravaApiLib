using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class ActivityDetailsDto : ActivityDto
    {
        [JsonPropertyName("elev_high")]
        public double? ElevHigh { get; set; }

        [JsonPropertyName("elev_low")]
        public double? ElevLow { get; set; }

        [JsonPropertyName("calories")]
        public double? Calories { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("average_temp")]
        public int? AverageTemp { get; set; }

        [JsonPropertyName("segment_efforts")]
        public List<SegmentEffortDto> SegmentEfforts { get; set; }

        [JsonPropertyName("splits_metric")]
        public List<SplitDto> SplitsMetric { get; set; }

        [JsonPropertyName("laps")]
        public List<LapDto> Laps { get; set; }

        [JsonPropertyName("gear")]
        public GearDto Gear { get; set; }

        [JsonPropertyName("photos")]
        public PhotosDto Photos { get; set; }

        [JsonPropertyName("highlighted_kudosers")]
        public List<KudoserDto> HighlightedKudosers { get; set; }

        [JsonPropertyName("embed_token")]
        public string EmbedToken { get; set; }

        [JsonPropertyName("hide_from_home")]
        public bool HideFromHome { get; set; }

        [JsonPropertyName("segment_leaderboard_opt_out")]
        public bool SegmentLeaderboardOptOut { get; set; }

        [JsonPropertyName("leaderboard_opt_out")]
        public bool LeaderboardOptOut { get; set; }
    }
}
