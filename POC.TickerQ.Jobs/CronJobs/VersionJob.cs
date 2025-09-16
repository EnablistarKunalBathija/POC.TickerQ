using POC.TickerQ.Common;
using TickerQ.Utilities.Base;

namespace POC.TickerQ.Jobs.CronJobs;

public class VersionJob
{
    private readonly ApplicationDbContext _applicationDbContext;

    public VersionJob(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [TickerFunction("ActivateVersion 2.0")]
    public async Task ActivateVersion()
    {
        try
        {
            Console.WriteLine("\n\n ActivateVersion Started.");

            var existingVersion = _applicationDbContext.Versions.OrderByDescending(i => i.Id).FirstOrDefault();

            existingVersion.IsActive = true;
            _applicationDbContext.SaveChanges();
            Console.WriteLine($"Activated Version Name: {existingVersion?.Name}\n\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n\n ActivateJob Error: {ex.Message}\n\n");
            throw;
        }
    }
}
