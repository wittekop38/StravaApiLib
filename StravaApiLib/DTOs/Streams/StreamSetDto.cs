using System.Text.Json.Serialization;

namespace StravaApiLib.DTOs.Streams
{
    /// <summary>
    /// Collection of activity/route/segment data streams, keyed by type.
    /// Properties are null when the corresponding stream was not requested or is unavailable.
    /// </summary>
    public class StreamSetDto
    {
        /// <summary>Seconds elapsed since the start of the activity.</summary>
        [JsonPropertyName("time")]
        public StreamDto<int>? Time { get; set; }

        /// <summary>Distance in meters from the start.</summary>
        [JsonPropertyName("distance")]
        public StreamDto<double>? Distance { get; set; }

        /// <summary>[latitude, longitude] pairs.</summary>
        [JsonPropertyName("latlng")]
        public StreamDto<double[]>? Latlng { get; set; }

        /// <summary>Altitude in meters above sea level.</summary>
        [JsonPropertyName("altitude")]
        public StreamDto<double>? Altitude { get; set; }

        /// <summary>Smoothed speed in m/s.</summary>
        [JsonPropertyName("velocity_smooth")]
        public StreamDto<double>? VelocitySmooth { get; set; }

        /// <summary>Heart rate in bpm.</summary>
        [JsonPropertyName("heartrate")]
        public StreamDto<int>? Heartrate { get; set; }

        /// <summary>Cadence in rpm.</summary>
        [JsonPropertyName("cadence")]
        public StreamDto<int>? Cadence { get; set; }

        /// <summary>Power output in watts.</summary>
        [JsonPropertyName("watts")]
        public StreamDto<int>? Watts { get; set; }

        /// <summary>Temperature in degrees Celsius.</summary>
        [JsonPropertyName("temp")]
        public StreamDto<int>? Temp { get; set; }

        /// <summary>Whether the athlete was moving at each point.</summary>
        [JsonPropertyName("moving")]
        public StreamDto<bool>? Moving { get; set; }

        /// <summary>Smoothed grade in percent.</summary>
        [JsonPropertyName("grade_smooth")]
        public StreamDto<double>? GradeSmooth { get; set; }
    }

    /// <summary>
    /// Stream type key constants for use with stream endpoints.
    /// </summary>
    public static class StreamKeys
    {
        public const string Time = "time";
        public const string Distance = "distance";
        public const string Latlng = "latlng";
        public const string Altitude = "altitude";
        public const string VelocitySmooth = "velocity_smooth";
        public const string Heartrate = "heartrate";
        public const string Cadence = "cadence";
        public const string Watts = "watts";
        public const string Temp = "temp";
        public const string Moving = "moving";
        public const string GradeSmooth = "grade_smooth";

        public static readonly string[] All =
        [
            Time, Distance, Latlng, Altitude, VelocitySmooth,
            Heartrate, Cadence, Watts, Temp, Moving, GradeSmooth
        ];
    }
}
