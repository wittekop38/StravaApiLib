using StravaApiLib.DTOs;
using StravaApiLib.DTOs.Activities;
using StravaApiLib.DTOs.Athletes;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Returns the authenticated athlete's activities. Requires activity:read.
        /// Only-me activities are excluded unless the token has activity:read_all.
        /// </summary>
        public async Task<List<ActivityDto>> GetActivitiesAsync(
            int page = 1, int perPage = 30, long? before = null, long? after = null)
        {
            var url = $"athlete/activities?page={page}&per_page={perPage}";
            if (before.HasValue) url += $"&before={before}";
            if (after.HasValue) url += $"&after={after}";
            return await GetAsync<List<ActivityDto>>(url) ?? [];
        }

        /// <summary>
        /// Returns detailed information for a specific activity. Requires activity:read.
        /// </summary>
        public async Task<ActivityDetailsDto?> GetActivityDetailsAsync(long activityId, bool includeAllEfforts = false)
        {
            return await GetAsync<ActivityDetailsDto>($"activities/{activityId}?include_all_efforts={includeAllEfforts.ToString().ToLower()}");
        }

        /// <summary>
        /// Creates a new activity for the authenticated athlete. Requires activity:write.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="sportType">Sport type (e.g. "Run", "Ride", "Swim").</param>
        /// <param name="startDateLocal">Local start time.</param>
        /// <param name="elapsedTimeSeconds">Total elapsed time in seconds.</param>
        /// <param name="description">Optional description.</param>
        /// <param name="distanceMeters">Optional distance in meters.</param>
        /// <param name="trainer">Set true for a trainer (indoor) activity.</param>
        /// <param name="commute">Set true to mark as a commute.</param>
        /// <param name="hideFromHome">Set true to hide from followers' feeds.</param>
        public async Task<ActivityDetailsDto?> CreateActivityAsync(
            string name,
            string sportType,
            DateTime startDateLocal,
            int elapsedTimeSeconds,
            string? description = null,
            float? distanceMeters = null,
            bool trainer = false,
            bool commute = false,
            bool hideFromHome = false)
        {
            var fields = new Dictionary<string, string>
            {
                { "name", name },
                { "sport_type", sportType },
                { "start_date_local", startDateLocal.ToString("yyyy-MM-ddTHH:mm:ssZ") },
                { "elapsed_time", elapsedTimeSeconds.ToString() },
                { "trainer", trainer ? "1" : "0" },
                { "commute", commute ? "1" : "0" },
                { "hide_from_home", hideFromHome.ToString().ToLower() }
            };
            if (description != null) fields["description"] = description;
            if (distanceMeters.HasValue) fields["distance"] = distanceMeters.Value.ToString("F1");

            return await PostFormAsync<ActivityDetailsDto>("activities", fields);
        }

        /// <summary>
        /// Updates a specific activity. Requires activity:write.
        /// Only set the properties you want to change — null values are ignored.
        /// </summary>
        public async Task<ActivityDetailsDto?> UpdateActivityAsync(long activityId, UpdateActivityRequestDto update)
        {
            return await PutJsonAsync<ActivityDetailsDto>($"activities/{activityId}", update);
        }

        /// <summary>
        /// Returns comments for a specific activity. Requires activity:read.
        /// </summary>
        public async Task<List<CommentDto>> GetActivityCommentsAsync(long activityId, int page = 1, int perPage = 30)
        {
            return await GetAsync<List<CommentDto>>($"activities/{activityId}/comments?page={page}&per_page={perPage}") ?? [];
        }

        /// <summary>
        /// Returns athletes who kudoed a specific activity. Requires activity:read.
        /// </summary>
        public async Task<List<SummaryAthleteDto>> GetActivityKudosAsync(long activityId, int page = 1, int perPage = 30)
        {
            return await GetAsync<List<SummaryAthleteDto>>($"activities/{activityId}/kudos?page={page}&per_page={perPage}") ?? [];
        }

        /// <summary>
        /// Returns laps for a specific activity. Requires activity:read.
        /// </summary>
        public async Task<List<LapDto>> GetActivityLapsAsync(long activityId)
        {
            return await GetAsync<List<LapDto>>($"activities/{activityId}/laps") ?? [];
        }

        /// <summary>
        /// Returns heart rate and power zones for a specific activity. Requires activity:read.
        /// </summary>
        public async Task<List<ActivityZoneDto>> GetActivityZonesAsync(long activityId)
        {
            return await GetAsync<List<ActivityZoneDto>>($"activities/{activityId}/zones") ?? [];
        }
    }
}
