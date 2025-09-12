using Microsoft.EntityFrameworkCore;

namespace POC.TickerQ.Jobs.Data;

public class TickerQDbContext(DbContextOptions<TickerQDbContext> options) : DbContext(options)
{
}
