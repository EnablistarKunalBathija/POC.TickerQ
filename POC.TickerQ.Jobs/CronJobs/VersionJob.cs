using POC.TickerQ.Jobs.Helper;
using TickerQ.Utilities.Base;

namespace POC.TickerQ.Jobs.CronJobs;

public class VersionJob
{
    [TickerFunction("ActivateVersion")]
    public async Task ActivateVersion()
    {
        try
        {
            Console.WriteLine("\n \n \n ActivateVersion Started.");

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5192/") // your WebAPI base URL
            };

            var client = new VersionClient(httpClient);
            var updatedVersion = await client.ActivateLatestVersionAsync();

            Console.WriteLine($"Activated Version Name: {updatedVersion?.Name} \n \n \n \n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n \n \n \n ActivateJob Error: {ex.Message} \n \n \n \n", ex);
            throw;
        }
    }
}
