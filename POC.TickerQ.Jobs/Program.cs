using Microsoft.EntityFrameworkCore;
using POC.TickerQ.Common;
using POC.TickerQ.Jobs.CronJobs;
using POC.TickerQ.Jobs.Data;
using POC.TickerQ.Jobs.Helper;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DependencyInjection;

namespace POC.TickerQ.Jobs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<TickerQDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsHistoryTable("__EFMigrationsHistory", "public")));

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddTickerQ(options =>
        {
            options.SetMaxConcurrency(Environment.ProcessorCount);
            options.UpdateMissedJobCheckDelay(TimeSpan.FromSeconds(5));

            options.SetInstanceIdentifier("KunalLocalMachine");
            options.AddOperationalStore<TickerQDbContext>(efOpt =>
            {
                efOpt.UseModelCustomizerForMigrations();
            });
            options.AddDashboard(dbOpt =>
            {
                dbOpt.BasePath = "/dashboard";
            });
        });

        var app = builder.Build();

        app.UseTickerQ();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
