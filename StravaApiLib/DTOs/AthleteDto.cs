using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs
{
    public class AthleteDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("sex")]
        public string Sex { get; set; }

        [JsonPropertyName("premium")]
        public bool Premium { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("badge_type_id")]
        public int BadgeTypeId { get; set; }

        [JsonPropertyName("profile_medium")]
        public string ProfileMedium { get; set; }

        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        [JsonPropertyName("follower_count")]
        public int FollowerCount { get; set; }

        [JsonPropertyName("friend_count")]
        public int FriendCount { get; set; }

        [JsonPropertyName("athlete_type")]
        public int AthleteType { get; set; }

        [JsonPropertyName("date_preference")]
        public string DatePreference { get; set; }

        [JsonPropertyName("measurement_preference")]
        public string MeasurementPreference { get; set; }

        [JsonPropertyName("ftp")]
        public int? Ftp { get; set; } // FIX (int, not double)

        [JsonPropertyName("weight")]
        public double? Weight { get; set; } // can be null

        [JsonPropertyName("bikes")]
        public List<GearDto> Bikes { get; set; }

        [JsonPropertyName("shoes")]
        public List<GearDto> Shoes { get; set; }
    }
}
