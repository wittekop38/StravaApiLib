namespace StravaApiLib.Debug
{
    public class Program
    {
        internal static async Task Main(string[] args)
        {
            var clientId = "";
            var clientSecret = "";
            var refreshToken = "";
            var url = StravaApi.GetAuthorizationUrl(clientId, "http://localhost:5000/callback");
            // user logs in → copy code
            //var (access, refresh) = await StravaApi.ExchangeCodeAsync(clientId, clientSecret, "");

            //Console.WriteLine(refresh);
            var program = new StravaApi(clientId, clientSecret, refreshToken, 30);
            var athlete = await program.GetAthleteAsync();
            var activities = await program.GetActivitiesAsync();
            var detailsActivity = await program.GetActivityDetailsAsync(activities.FirstOrDefault().Id, true);

            var routes = await program.GetRoutesByAthleteIdAsync(athlete.Id);
            var specificRoute = await program.GetRouteAsync(routes.FirstOrDefault().Id);
        }
    }
}
