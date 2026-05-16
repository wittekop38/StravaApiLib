using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs.Athletes
{
    public class MetaAthleteDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
