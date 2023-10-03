using Cache_Maktab97.Infrastructure.EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cache_Maktab97.Infrastructure.EfCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<CityDbEntity> Cities { get; set; }
}
