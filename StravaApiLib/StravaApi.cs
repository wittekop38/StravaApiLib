using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StravaApiLib
{
    /// <summary>
    /// Lightweight wrapper for the Strava API v3.
    /// Handles authentication (OAuth refresh token flow) and all API requests.
    /// </summary>
    /// <remarks>
    /// Construct with your Strava application credentials and a refresh token,
    /// or use <see cref="GetAuthorizationUrl"/> and <see cref="ExchangeCodeAsync"/> to perform the initial OAuth flow.
    /// </remarks>
    public partial class StravaApi
    {
        private const string BaseUrl = "https://www.strava.com/api/v3/";
        private const string OAuthUrl = "https://www.strava.com/oauth/token";

        private static readonly JsonSerializerOptions _writeOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        private readonly HttpClient _http;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _refreshToken;

        private string? _accessToken;
        private DateTime _accessTokenExpiresAt;

        /// <param name="clientId">Strava application client ID.</param>
        /// <param name="clientSecret">Strava application client secret.</param>
        /// <param name="refreshToken">OAuth refresh token from the initial authorization flow.</param>
        /// <param name="timeOutSeconds">HTTP request timeout in seconds (default 30).</param>
        public StravaApi(string clientId, string clientSecret, string refreshToken, int timeOutSeconds = 30)
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

        private async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _accessTokenExpiresAt)
                return _accessToken;

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

        private async Task<HttpRequestMessage> BuildRequestAsync(HttpMethod method, string url)
        {
            var token = await GetAccessTokenAsync();
            var request = new HttpRequestMessage(method, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return request;
        }

        private async Task<T?> GetAsync<T>(string url)
        {
            using var request = await BuildRequestAsync(HttpMethod.Get, url);
            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task<byte[]> GetBytesAsync(string url)
        {
            using var request = await BuildRequestAsync(HttpMethod.Get, url);
            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        private async Task<T?> PostFormAsync<T>(string url, Dictionary<string, string> fields)
        {
            using var request = await BuildRequestAsync(HttpMethod.Post, url);
            request.Content = new FormUrlEncodedContent(fields);
            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task<T?> PostJsonAsync<T>(string url, object body)
        {
            using var request = await BuildRequestAsync(HttpMethod.Post, url);
            request.Content = new StringContent(JsonSerializer.Serialize(body, _writeOptions), Encoding.UTF8, "application/json");
            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task<T?> PostMultipartAsync<T>(string url, MultipartFormDataContent content)
        {
            using var request = await BuildRequestAsync(HttpMethod.Post, url);
            request.Content = content;
            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task<T?> PutFormAsync<T>(string url, Dictionary<string, string> fields)
        {
            using var request = await BuildRequestAsync(HttpMethod.Put, url);
            request.Content = new FormUrlEncodedContent(fields);
            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task<T?> PutJsonAsync<T>(string url, object body)
        {
            using var request = await BuildRequestAsync(HttpMethod.Put, url);
            request.Content = new StringContent(JsonSerializer.Serialize(body, _writeOptions), Encoding.UTF8, "application/json");
            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        /// <summary>
        /// Generates the Strava OAuth authorization URL to open in a browser.
        /// After user approval, Strava redirects to <paramref name="redirectUri"/> with a <c>code</c> query parameter
        /// that can be exchanged via <see cref="ExchangeCodeAsync"/>.
        /// </summary>
        public static string GetAuthorizationUrl(string clientId, string redirectUri)
        {
            return "https://www.strava.com/oauth/authorize" +
                   $"?client_id={clientId}" +
                   "&response_type=code" +
                   $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                   "&approval_prompt=force" +
                   "&scope=read,activity:read_all,profile:read_all";
        }

        /// <summary>
        /// Exchanges an authorization code for access and refresh tokens.
        /// </summary>
        /// <returns>A tuple of (accessToken, refreshToken).</returns>
        public static async Task<(string accessToken, string refreshToken)> ExchangeCodeAsync(
            string clientId, string clientSecret, string code)
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
