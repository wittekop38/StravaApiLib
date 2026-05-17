using StravaApiLib.DTOs.Gear;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Returns detailed information about a gear item (bike or shoes).
        /// </summary>
        /// <param name="gearId">Gear ID from an activity or athlete profile (e.g. "b12345678").</param>
        public async Task<GearDto?> GetGearAsync(string gearId)
        {
            if (string.IsNullOrWhiteSpace(gearId)) throw new ArgumentException("Gear ID cannot be null or empty.", nameof(gearId));
            return await GetAsync<GearDto>($"gear/{gearId}");
        }
    }
}
