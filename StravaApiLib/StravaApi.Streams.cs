using StravaApiLib.DTOs.Streams;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Returns data streams for an activity. Requires activity:read.
        /// Use <see cref="StreamKeys"/> constants for the <paramref name="keys"/> parameter.
        /// </summary>
        /// <param name="activityId">Activity to fetch streams for.</param>
        /// <param name="keys">Stream types to include (e.g. StreamKeys.Time, StreamKeys.Heartrate).</param>
        public async Task<StreamSetDto?> GetActivityStreamsAsync(long activityId, params string[] keys)
        {
            var joined = string.Join(",", keys);
            return await GetAsync<StreamSetDto>($"activities/{activityId}/streams?keys={joined}&key_by_type=true");
        }

        /// <summary>
        /// Returns all data streams for a route.
        /// </summary>
        public async Task<StreamSetDto?> GetRouteStreamsAsync(long routeId)
        {
            return await GetAsync<StreamSetDto>($"routes/{routeId}/streams?key_by_type=true");
        }

        /// <summary>
        /// Returns data streams for a segment effort. Requires activity:read.
        /// Use <see cref="StreamKeys"/> constants for the <paramref name="keys"/> parameter.
        /// </summary>
        public async Task<StreamSetDto?> GetSegmentEffortStreamsAsync(long effortId, params string[] keys)
        {
            var joined = string.Join(",", keys);
            return await GetAsync<StreamSetDto>($"segment_efforts/{effortId}/streams?keys={joined}&key_by_type=true");
        }

        /// <summary>
        /// Returns data streams for a segment.
        /// Use <see cref="StreamKeys"/> constants for the <paramref name="keys"/> parameter.
        /// </summary>
        public async Task<StreamSetDto?> GetSegmentStreamsAsync(long segmentId, params string[] keys)
        {
            var joined = string.Join(",", keys);
            return await GetAsync<StreamSetDto>($"segments/{segmentId}/streams?keys={joined}&key_by_type=true");
        }
    }
}
