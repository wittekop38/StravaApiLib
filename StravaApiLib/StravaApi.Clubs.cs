using StravaApiLib.DTOs.Clubs;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Returns a specific club. Requires club:read_all for private clubs.
        /// </summary>
        public async Task<ClubDto?> GetClubAsync(long clubId)
        {
            return await GetAsync<ClubDto>($"clubs/{clubId}");
        }

        /// <summary>
        /// Returns the clubs the authenticated athlete belongs to. Requires club:read_all.
        /// </summary>
        public async Task<List<SummaryClubDto>> GetAthleteClubsAsync(int page = 1, int perPage = 30)
        {
            return await GetAsync<List<SummaryClubDto>>($"athlete/clubs?page={page}&per_page={perPage}") ?? [];
        }

        /// <summary>
        /// Returns recent activities from a club's feed. Requires club:read_all.
        /// </summary>
        public async Task<List<ClubActivityDto>> GetClubActivitiesAsync(long clubId, int page = 1, int perPage = 30)
        {
            return await GetAsync<List<ClubActivityDto>>($"clubs/{clubId}/activities?page={page}&per_page={perPage}") ?? [];
        }

        /// <summary>
        /// Returns members of a club. Requires club:read_all.
        /// </summary>
        public async Task<List<ClubAthleteDto>> GetClubMembersAsync(long clubId, int page = 1, int perPage = 30)
        {
            return await GetAsync<List<ClubAthleteDto>>($"clubs/{clubId}/members?page={page}&per_page={perPage}") ?? [];
        }

        /// <summary>
        /// Returns admins of a club. Requires club:read_all.
        /// </summary>
        public async Task<List<ClubAthleteDto>> GetClubAdminsAsync(long clubId, int page = 1, int perPage = 30)
        {
            return await GetAsync<List<ClubAthleteDto>>($"clubs/{clubId}/admins?page={page}&per_page={perPage}") ?? [];
        }
    }
}
