using StravaApiLib.DTOs.Segment;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Returns a specific segment.
        /// </summary>
        public async Task<DetailedSegmentDto?> GetSegmentAsync(long segmentId)
        {
            return await GetAsync<DetailedSegmentDto>($"segments/{segmentId}");
        }

        /// <summary>
        /// Returns the authenticated athlete's starred segments.
        /// </summary>
        public async Task<List<SummarySegmentDto>> GetStarredSegmentsAsync(int page = 1, int perPage = 30)
        {
            return await GetAsync<List<SummarySegmentDto>>($"athlete/segments/starred?page={page}&per_page={perPage}") ?? [];
        }

        /// <summary>
        /// Stars or un-stars a segment for the authenticated athlete. Requires segment:write.
        /// </summary>
        /// <param name="segmentId">Segment to star or un-star.</param>
        /// <param name="starred">True to star, false to un-star.</param>
        public async Task<DetailedSegmentDto?> StarSegmentAsync(long segmentId, bool starred)
        {
            return await PutFormAsync<DetailedSegmentDto>($"segments/{segmentId}/starred", new Dictionary<string, string>
            {
                { "starred", starred.ToString().ToLower() }
            });
        }

        /// <summary>
        /// Searches for segments in a geographic area.
        /// </summary>
        /// <param name="bounds">Bounding box as "swLat,swLng,neLat,neLng".</param>
        /// <param name="activityType">Optional filter: "running" or "riding".</param>
        /// <param name="minClimbCategory">Minimum climb category (0–5).</param>
        /// <param name="maxClimbCategory">Maximum climb category (0–5).</param>
        public async Task<ExplorerResponseDto?> ExploreSegmentsAsync(
            string bounds,
            string? activityType = null,
            int? minClimbCategory = null,
            int? maxClimbCategory = null)
        {
            var url = $"segments/explore?bounds={Uri.EscapeDataString(bounds)}";
            if (activityType != null) url += $"&activity_type={activityType}";
            if (minClimbCategory.HasValue) url += $"&min_cat={minClimbCategory}";
            if (maxClimbCategory.HasValue) url += $"&max_cat={maxClimbCategory}";
            return await GetAsync<ExplorerResponseDto>(url);
        }

        /// <summary>
        /// Returns efforts on a segment filtered by date. Requires activity:read.
        /// </summary>
        /// <param name="segmentId">Segment to query.</param>
        /// <param name="startDateLocal">Optional start of filter window (local time).</param>
        /// <param name="endDateLocal">Optional end of filter window (local time).</param>
        /// <param name="perPage">Number of results per page.</param>
        public async Task<List<SegmentEffortDto>> GetSegmentEffortsAsync(
            long segmentId,
            DateTime? startDateLocal = null,
            DateTime? endDateLocal = null,
            int perPage = 30)
        {
            var url = $"segments/{segmentId}/all_efforts?per_page={perPage}";
            if (startDateLocal.HasValue) url += $"&start_date_local={Uri.EscapeDataString(startDateLocal.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"))}";
            if (endDateLocal.HasValue) url += $"&end_date_local={Uri.EscapeDataString(endDateLocal.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"))}";
            return await GetAsync<List<SegmentEffortDto>>(url) ?? [];
        }

        /// <summary>
        /// Returns a specific segment effort. Requires activity:read.
        /// </summary>
        public async Task<SegmentEffortDto?> GetSegmentEffortAsync(long effortId)
        {
            return await GetAsync<SegmentEffortDto>($"segment_efforts/{effortId}");
        }
    }
}
