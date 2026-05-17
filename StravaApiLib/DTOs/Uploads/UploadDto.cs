using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Uploads
{
    public class UploadDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("id_str")]
        public string? IdStr { get; set; }

        [JsonPropertyName("external_id")]
        public string? ExternalId { get; set; }

        /// <summary>Error message if processing failed, null otherwise.</summary>
        [JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>Processing status: "Your activity is still being processed.", "The created activity has been deleted.", "There was an error processing your activity.", or "Your activity is ready."</summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>ID of the created activity once processing completes. Null while still processing.</summary>
        [JsonPropertyName("activity_id")]
        public long? ActivityId { get; set; }
    }
}
