namespace StravaApiLib.Debug
{
    public class Program
    {
        internal static async Task Main(string[] args)
        {
            var clientId = "";
            var clientSecret = "";
            var refreshToken = "";
            var program = new StravaApi(clientId, clientSecret, refreshToken, 30);
            var activities = await program.GetActivitiesAsync();
            Console.WriteLine($"Retrieved {activities.Count} activities.");
        }
    }
}
