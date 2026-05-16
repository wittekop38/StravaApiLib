using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs.Athletes
{
    public class AthleteStatsDto
    {
        [JsonPropertyName("recent_ride_totals")]
        public ActivityTotalDto RecentRideTotals { get; set; }

        [JsonPropertyName("ytd_ride_totals")]
        public ActivityTotalDto YtdRideTotals { get; set; }

        [JsonPropertyName("all_ride_totals")]
        public ActivityTotalDto AllRideTotals { get; set; }

        [JsonPropertyName("recent_run_totals")]
        public ActivityTotalDto RecentRunTotals { get; set; }

        [JsonPropertyName("ytd_run_totals")]
        public ActivityTotalDto YtdRunTotals { get; set; }

        [JsonPropertyName("all_run_totals")]
        public ActivityTotalDto AllRunTotals { get; set; }

        [JsonPropertyName("recent_swim_totals")]
        public ActivityTotalDto RecentSwimTotals { get; set; }

        [JsonPropertyName("ytd_swim_totals")]
        public ActivityTotalDto YtdSwimTotals { get; set; }

        [JsonPropertyName("all_swim_totals")]
        public ActivityTotalDto AllSwimTotals { get; set; }

        [JsonPropertyName("biggest_ride_distance")]
        public double BiggestRideDistance { get; set; }

        [JsonPropertyName("biggest_climb_elevation_gain")]
        public double BiggestClimbElevationGain { get; set; }
    }

    public class ActivityTotalDto
    {
        public double Distance { get; set; }
        public int AchievementCount { get; set; }
        public int Count { get; set; }
        public int ElapsedTime { get; set; }
        public double ElevationGain { get; set; }
        public int MovingTime { get; set; }
    }
}
