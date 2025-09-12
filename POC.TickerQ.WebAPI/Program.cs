using Microsoft.EntityFrameworkCore;
using POC.TickerQ.Common;

namespace POC.TickerQ.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext>(options => 
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsHistoryTable("__EFMigrationsHistory", "public")));

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
