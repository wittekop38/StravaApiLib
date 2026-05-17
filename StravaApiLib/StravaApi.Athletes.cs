using StravaApiLib.DTOs.Athletes;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Returns the currently authenticated athlete. Requires profile:read_all for detailed representation.
        /// </summary>
        public async Task<AthleteDto?> GetAthleteAsync()
        {
            return await GetAsync<AthleteDto>("athlete");
        }

        /// <summary>
        /// Returns the heart rate and power zones of the authenticated athlete. Requires profile:read_all.
        /// </summary>
        public async Task<ZonesDto?> GetAthleteZonesAsync()
        {
            return await GetAsync<ZonesDto>("athlete/zones");
        }

        /// <summary>
        /// Updates the authenticated athlete's weight. Requires profile:write.
        /// </summary>
        /// <param name="weight">Weight in kilograms.</param>
        public async Task<AthleteDto?> UpdateAthleteAsync(float weight)
        {
            return await PutFormAsync<AthleteDto>("athlete", new Dictionary<string, string>
            {
                { "weight", weight.ToString("F2") }
            });
        }

        /// <summary>
        /// Returns activity stats for an athlete. Only includes public activities.
        /// </summary>
        /// <param name="athleteId">Must match the authenticated athlete's ID.</param>
        public async Task<AthleteStatsDto?> GetAthleteStatsAsync(long athleteId)
        {
            return await GetAsync<AthleteStatsDto>($"athletes/{athleteId}/stats");
        }
    }
}
