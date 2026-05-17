using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Clubs
{
    public class ClubDto : SummaryClubDto
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("club_type")]
        public string? ClubType { get; set; }

        [JsonPropertyName("following_count")]
        public int FollowingCount { get; set; }

        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [JsonPropertyName("owner")]
        public bool Owner { get; set; }
    }
}
