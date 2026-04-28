using StravaApiLib.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace StravaApiLib
{
    public class StravaApi
    {
        private const string BaseUrl = "https://www.strava.com/api/v3/";
        private const string OAuthUrl = "https://www.strava.com/oauth/token";
        private readonly HttpClient _http;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _refreshToken;
        private string _accessToken;
        private DateTime _accessTokenExpiresAt;
        public int TimeoutSeconds { get; set; } = 30;

        public StravaApi(string clientId, string clientSecret, string refreshToken, int timeOutSeconds)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromSeconds(timeOutSeconds)
            };
            _clientId = clientId;
            _clientSecret = clientSecret;
            _refreshToken = refreshToken;
        }

        // Automatic access token refresh
        private async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _accessTokenExpiresAt) return _accessToken;

            var response = await _http.PostAsync(OAuthUrl,
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", _clientId },
                    { "client_secret", _clientSecret },
                    { "grant_type", "refresh_token" },
                    { "refresh_token", _refreshToken }
                }));
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            _accessToken = json.GetProperty("access_token").GetString();
            var expiresAt = json.GetProperty("expires_at").GetInt64();
            _accessTokenExpiresAt = DateTimeOffset.FromUnixTimeSeconds(expiresAt).UtcDateTime;

            return _accessToken;
        }

        public async Task<List<ActivityDto>> GetActivitiesAsync(int page = 1, int perPage = 30, long? before = null, long? after = null)
        {
            var url = $"athlete/activities?page={page}&per_page={perPage}";

            if (before.HasValue) url += $"&before={before}";
            if (after.HasValue) url += $"&after={after}";

            return await GetAsync<List<ActivityDto>>(url) ?? new();
        }

        public async Task<ActivityDetailsDto> GetActivityDetailsAsync(long activityId, bool includeAllEfforts = false)
        {
            var url = $"activities/{activityId}?include_all_efforts={includeAllEfforts.ToString().ToLower()}";

            return await GetAsync<ActivityDetailsDto>(url);
        }

        public async Task<AthleteDto> GetAthleteAsync()
        {
            return await GetAsync<AthleteDto>("athlete");
        }

        public async Task<AthleteStatsDto> GetAthleteStatsAsync(long athleteId)
        {
            return await GetAsync<AthleteStatsDto>($"athletes/{athleteId}/stats");
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var token = await GetAccessTokenAsync();

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
