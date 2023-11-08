using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Application_BE_Project.EntityFramework;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Configuration.GetConnectionString("sqlServer") ?? throw new ArgumentException(("connectionString"));
        options.UseSqlServer(connectionString);

        options.LogTo(Console.WriteLine);
    }
}
