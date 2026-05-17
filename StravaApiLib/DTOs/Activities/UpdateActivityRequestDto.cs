using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Activities
{
    /// <summary>
    /// Fields for updating an existing activity via <c>PUT /activities/{id}</c>.
    /// Only non-null properties are sent to the API.
    /// </summary>
    public class UpdateActivityRequestDto
    {
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("sport_type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SportType { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("gear_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GearId { get; set; }

        [JsonPropertyName("commute")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Commute { get; set; }

        [JsonPropertyName("trainer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Trainer { get; set; }

        [JsonPropertyName("hide_from_home")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HideFromHome { get; set; }
    }
}
