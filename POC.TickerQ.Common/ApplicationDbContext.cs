using Microsoft.EntityFrameworkCore;
using POC.TickerQ.Common.Entities;
using TickerQ.EntityFrameworkCore.Configurations;

namespace POC.TickerQ.Common;

//public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
//{
//}

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<VersionEntity> Versions { get; set; }
}
