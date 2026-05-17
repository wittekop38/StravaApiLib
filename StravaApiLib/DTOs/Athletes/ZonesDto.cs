using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Athletes
{
    public class ZonesDto
    {
        [JsonPropertyName("heart_rate")]
        public HeartRateZoneRangesDto? HeartRate { get; set; }

        [JsonPropertyName("power")]
        public PowerZoneRangesDto? Power { get; set; }
    }

    public class HeartRateZoneRangesDto
    {
        [JsonPropertyName("custom_zones")]
        public bool CustomZones { get; set; }

        [JsonPropertyName("zones")]
        public List<ZoneRangeDto> Zones { get; set; } = [];
    }

    public class PowerZoneRangesDto
    {
        [JsonPropertyName("zones")]
        public List<ZoneRangeDto> Zones { get; set; } = [];
    }

    public class ZoneRangeDto
    {
        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }
    }
}
