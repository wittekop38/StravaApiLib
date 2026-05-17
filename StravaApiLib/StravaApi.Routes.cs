using StravaApiLib.DTOs.Routes;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Returns a route by ID. Requires read_all scope for private routes.
        /// </summary>
        public async Task<RouteDto?> GetRouteAsync(long routeId)
        {
            return await GetAsync<RouteDto>($"routes/{routeId}");
        }

        /// <summary>
        /// Returns routes created by an athlete. Private routes require read_all scope.
        /// </summary>
        public async Task<List<RouteDto>> GetRoutesByAthleteIdAsync(long athleteId, int page = 1, int perPage = 30)
        {
            return await GetAsync<List<RouteDto>>($"athletes/{athleteId}/routes?page={page}&per_page={perPage}") ?? [];
        }

        /// <summary>
        /// Downloads a route as a GPX file. Returns the raw file bytes.
        /// </summary>
        public async Task<byte[]> GetRouteAsGpxAsync(long routeId)
        {
            return await GetBytesAsync($"routes/{routeId}/export/gpx");
        }

        /// <summary>
        /// Downloads a route as a TCX file. Returns the raw file bytes.
        /// </summary>
        public async Task<byte[]> GetRouteAsTcxAsync(long routeId)
        {
            return await GetBytesAsync($"routes/{routeId}/export/tcx");
        }
    }
}
