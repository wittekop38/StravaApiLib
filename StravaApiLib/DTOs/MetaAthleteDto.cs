using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs
{
    public class MetaAthleteDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }
    }
}
