using Cache_Maktab97.Infrastructure.EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cache_Maktab97.Infrastructure.EfCore.Repositories;
public class BaseDataRepository : IBaseDataRepository
{
    private readonly AppDbContext _context;

    public BaseDataRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CityDbEntity>> GetAllCities(CancellationToken cancellationToken)
       => await _context.Cities.ToListAsync(cancellationToken);

}