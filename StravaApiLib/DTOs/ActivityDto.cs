using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class ActivityDto
    {
        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        [JsonPropertyName("athlete")]
        public MetaAthleteDto Athlete { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonPropertyName("total_elevation_gain")]
        public double TotalElevationGain { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("sport_type")]
        public string SportType { get; set; }

        [JsonPropertyName("workout_type")]
        public int? WorkoutType { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("upload_id")]
        public long? UploadId { get; set; } // can be null

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("start_date_local")]
        public DateTime StartDateLocal { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("utc_offset")]
        public double UtcOffset { get; set; }

        [JsonPropertyName("start_latlng")]
        public double[] StartLatlng { get; set; }

        [JsonPropertyName("end_latlng")]
        public double[] EndLatlng { get; set; }

        [JsonPropertyName("location_city")]
        public string LocationCity { get; set; }

        [JsonPropertyName("location_state")]
        public string LocationState { get; set; }

        [JsonPropertyName("location_country")]
        public string LocationCountry { get; set; }

        [JsonPropertyName("achievement_count")]
        public int AchievementCount { get; set; }

        [JsonPropertyName("kudos_count")]
        public int KudosCount { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        [JsonPropertyName("athlete_count")]
        public int AthleteCount { get; set; }

        [JsonPropertyName("photo_count")]
        public int PhotoCount { get; set; }

        [JsonPropertyName("total_photo_count")]
        public int TotalPhotoCount { get; set; }

        [JsonPropertyName("map")]
        public MapDto Map { get; set; }

        [JsonPropertyName("device_name")]
        public string DeviceName { get; set; }

        [JsonPropertyName("trainer")]
        public bool Trainer { get; set; }

        [JsonPropertyName("commute")]
        public bool Commute { get; set; }

        [JsonPropertyName("manual")]
        public bool Manual { get; set; }

        [JsonPropertyName("private")]
        public bool Private { get; set; }

        [JsonPropertyName("flagged")]
        public bool Flagged { get; set; }

        [JsonPropertyName("gear_id")]
        public string GearId { get; set; }

        [JsonPropertyName("from_accepted_tag")]
        public bool FromAcceptedTag { get; set; }

        [JsonPropertyName("average_speed")]
        public double AverageSpeed { get; set; }

        [JsonPropertyName("max_speed")]
        public double MaxSpeed { get; set; }

        [JsonPropertyName("average_cadence")]
        public double? AverageCadence { get; set; }

        [JsonPropertyName("average_watts")]
        public double? AverageWatts { get; set; }

        [JsonPropertyName("weighted_average_watts")]
        public int? WeightedAverageWatts { get; set; }

        [JsonPropertyName("kilojoules")]
        public double? Kilojoules { get; set; }

        [JsonPropertyName("device_watts")]
        public bool DeviceWatts { get; set; }

        [JsonPropertyName("has_heartrate")]
        public bool HasHeartrate { get; set; }

        [JsonPropertyName("average_heartrate")]
        public double? AverageHeartrate { get; set; }

        [JsonPropertyName("max_heartrate")]
        public double? MaxHeartrate { get; set; }

        [JsonPropertyName("max_watts")]
        public int? MaxWatts { get; set; }

        [JsonPropertyName("pr_count")]
        public int PrCount { get; set; }

        [JsonPropertyName("has_kudoed")]
        public bool HasKudoed { get; set; }

        [JsonPropertyName("suffer_score")]
        public decimal? SufferScore { get; set; }
    }
}
