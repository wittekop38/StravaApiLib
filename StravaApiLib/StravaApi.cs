using StravaApiLib.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace StravaApiLib
{
    /// <summary>
    /// Lightweight wrapper for the Strava API v3.
    /// Handles authentication (OAuth refresh token flow) and API requests.
    /// </summary>
    /// <remarks>
    /// Usage (when consumed from a NuGet package):
    /// - Install the package (for example: <c>Install-Package StravaApiLib</c>).
    /// - Construct a <see cref="StravaApi"/> with your Strava application credentials and a refresh token,
    ///   or use <see cref="GetAuthorizationUrl"/> and <see cref="ExchangeCodeAsync"/> to perform the OAuth flow.
    /// See the <see cref="GetAuthorizationUrl(string, string)"/> example below for the authorization flow.
    /// </remarks>
    public class StravaApi
    {
        private const string BaseUrl = "https://www.strava.com/api/v3/";
        private const string OAuthUrl = "https://www.strava.com/oauth/token";

        private readonly HttpClient _http;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _refreshToken;

        private string? _accessToken;
        private DateTime _accessTokenExpiresAt;

        /// <summary>
        /// Default HTTP timeout in seconds for API requests.
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30;

        /// <summary>
        /// Creates a new instance of the Strava API client.
        /// </summary>
        /// <param name="clientId">Strava application client ID.</param>
        /// <param name="clientSecret">Strava application client secret.</param>
        /// <param name="refreshToken">
        /// OAuth refresh token obtained from the initial authorization flow.
        /// This token is used to generate access tokens automatically.
        /// </param>
        /// <param name="timeOutSeconds">HTTP request timeout in seconds.</param>
        /// <remarks>
        /// If you need to perform the full OAuth authorization flow, use <see cref="GetAuthorizationUrl"/> to
        /// obtain an authorization code and then call <see cref="ExchangeCodeAsync"/> to exchange the code for tokens.
        /// </remarks>
        /// <example>
        /// <code>
        /// var client = new StravaApi("yourClientId", "yourClientSecret", "yourRefreshToken", 60);
        /// var athlete = await client.GetAthleteAsync();
        /// </code>
        /// </example>
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

        /// <summary>
        /// Retrieves a valid access token using the refresh token flow.
        /// Automatically caches the token until expiration.
        /// </summary>
        /// <returns>A valid access token string.</returns>
        /// <exception cref="HttpRequestException">Thrown on network or non-success HTTP responses.</exception>
        private async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _accessTokenExpiresAt) return _accessToken;
            var response = await _http.PostAsync(OAuthUrl,
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", _clientId },
                    { "client_secret", _clientSecret },
                    { "refresh_token", _refreshToken },
                    { "grant_type", "refresh_token" }
                }));
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            _accessToken = json.GetProperty("access_token").GetString();
            var expiresAt = json.GetProperty("expires_at").GetInt64();
            _accessTokenExpiresAt = DateTimeOffset.FromUnixTimeSeconds(expiresAt).UtcDateTime;

            return _accessToken!;
        }

        /// <summary>
        /// Gets a paginated list of the authenticated athlete's activities.
        /// </summary>
        /// <param name="page">Page number (1-based).</param>
        /// <param name="perPage">Number of items per page.</param>
        /// <param name="before">Optional epoch seconds to only return activities before this time.</param>
        /// <param name="after">Optional epoch seconds to only return activities after this time.</param>
        /// <returns>A list of <see cref="ActivityDto"/> objects (may be empty).</returns>
        public async Task<List<ActivityDto>> GetActivitiesAsync(int page = 1, int perPage = 30, long? before = null, long? after = null)
        {
            var url = $"athlete/activities?page={page}&per_page={perPage}";
            if (before.HasValue) url += $"&before={before}";
            if (after.HasValue) url += $"&after={after}";

            return await GetAsync<List<ActivityDto>>(url) ?? new();
        }

        /// <summary>
        /// Retrieves detailed information for a specific activity.
        /// </summary>
        /// <param name="activityId">Activity identifier.</param>
        /// <param name="includeAllEfforts">Whether to include all segment efforts.</param>
        /// <returns>An <see cref="ActivityDetailsDto"/> describing the activity.</returns>
        public async Task<ActivityDetailsDto> GetActivityDetailsAsync(long activityId, bool includeAllEfforts = false)
        {
            var url = $"activities/{activityId}?include_all_efforts={includeAllEfforts.ToString().ToLower()}";

            return await GetAsync<ActivityDetailsDto>(url);
        }

        /// <summary>
        /// Gets the authenticated athlete profile.
        /// </summary>
        /// <returns>An <see cref="AthleteDto"/> describing the authenticated athlete.</returns>
        public async Task<AthleteDto> GetAthleteAsync()
        {
            return await GetAsync<AthleteDto>("athlete");
        }

        /// <summary>
        /// Retrieves statistics for a specific athlete.
        /// </summary>
        /// <param name="athleteId">Athlete identifier.</param>
        /// <returns>An <see cref="AthleteStatsDto"/> containing aggregated statistics for the athlete.</returns>
        public async Task<AthleteStatsDto> GetAthleteStatsAsync(long athleteId)
        {
            return await GetAsync<AthleteStatsDto>($"athletes/{athleteId}/stats");
        }

        /// <summary>
        /// Gets detailed information about a specific gear item (bike or shoes).
        /// </summary>
        /// <param name="gearId">Gear identifier from activity or athlete profile.</param>
        /// <returns>A <see cref="GearDto"/> describing the gear item.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="gearId"/> is null or empty.</exception>
        public async Task<GearDto> GetGearAsync(string gearId)
        {
            if (string.IsNullOrWhiteSpace(gearId)) throw new ArgumentException("Gear ID cannot be null or empty.", nameof(gearId));

            return await GetAsync<GearDto>($"gear/{gearId}");
        }

        /// <summary>
        /// Executes a GET request against the Strava API and deserializes the response.
        /// </summary>
        /// <typeparam name="T">Response DTO type.</typeparam>
        /// <param name="url">Relative API URL (without base).</param>
        /// <returns>Deserialized response object or default when the body is empty.</returns>
        /// <exception cref="HttpRequestException">Thrown on network or non-success HTTP responses.</exception>
        private async Task<T?> GetAsync<T>(string url)
        {
            var token = await GetAccessTokenAsync();
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        /// <summary>
        /// Generates the Strava OAuth authorization URL.
        /// </summary>
        /// <param name="clientId">Your Strava application client ID.</param>
        /// <param name="redirectUri">Redirect URI registered with your Strava app. Must match the redirect in Strava settings.</param>
        /// <returns>The URL to open in the user's browser to start the OAuth authorization flow.</returns>
        /// <remarks>
        /// Open the returned URL in a browser. After the user approves access, Strava will redirect to <paramref name="redirectUri"/>
        /// with a query parameter named <c>code</c>. That code can be exchanged for tokens using <see cref="ExchangeCodeAsync"/>.
        /// </remarks>
        /// <example>
        /// <code>
        /// var url = StravaApi.GetAuthorizationUrl("yourClientId", "https://yourapp/callback");
        /// // Open url in browser, then exchange the returned code:
        /// var (accessToken, refreshToken) = await StravaApi.ExchangeCodeAsync("yourClientId", "yourClientSecret", "theCodeFromCallback");
        /// </code>
        /// </example>
        public static string GetAuthorizationUrl(string clientId, string redirectUri)
        {
            return
                "https://www.strava.com/oauth/authorize" +
                $"?client_id={clientId}" +
                "&response_type=code" +
                $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                "&approval_prompt=force" +
                "&scope=read,activity:read_all,profile:read_all";
        }

        /// <summary>
        /// Exchanges an authorization code for an access token and refresh token.
        /// </summary>
        /// <param name="clientId">Your Strava application client ID.</param>
        /// <param name="clientSecret">Your Strava application client secret.</param>
        /// <param name="code">Authorization code received from Strava after user consent.</param>
        /// <returns>A tuple containing the <c>accessToken</c> and <c>refreshToken</c>.</returns>
        /// <remarks>
        /// This method should be called after the user completes the OAuth login and you receive the authorization code.
        /// The authorization code is single-use and short-lived.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown on network or non-success HTTP responses.</exception>
        public static async Task<(string accessToken, string refreshToken)> ExchangeCodeAsync(string clientId, string clientSecret, string code)
        {
            using var http = new HttpClient();

            var response = await http.PostAsync(OAuthUrl,
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "code", code },
                    { "grant_type", "authorization_code" }
                }));
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            return (json.GetProperty("access_token").GetString()!, json.GetProperty("refresh_token").GetString()!);
        }
    }
}