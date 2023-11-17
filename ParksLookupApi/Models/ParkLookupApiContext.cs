using Microsoft.EntityFrameworkCore;

namespace ParkLookupApi.Models
{
  public class ParkLookupApiContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }

    public ParkLookupApiContext(DbContextOptions<ParkLookupApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Yellowstone National Park", Location = "United States", Climate = "subarctic" },
          new Park { ParkId = 2, Name = "Banff National Park", Location = "Canada", Climate = "subarctic" },
          new Park { ParkId = 3, Name = "Kruger National Park", Location ="South Africa", Climate = "subtropical" },
          new Park { ParkId = 4, Name = "Yosemites National Park", Location = "United States", Climate = "mediterranean" },
          new Park { ParkId = 5, Name = "Torres del Paine National Park", Location = "Chile", Climate = "temperate" }
        );
    }
  }
}