using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Clubs
{
    public class ClubAthleteDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; }

        [JsonPropertyName("profile_medium")]
        public string? ProfileMedium { get; set; }

        [JsonPropertyName("profile")]
        public string? Profile { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sex")]
        public string? Sex { get; set; }

        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [JsonPropertyName("owner")]
        public bool Owner { get; set; }

        [JsonPropertyName("membership")]
        public string? Membership { get; set; }
    }
}
