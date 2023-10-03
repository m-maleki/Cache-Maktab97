using Cache_Maktab97.Infrastructure.EfCore.Entities;

namespace Cache_Maktab97.Infrastructure.EfCore.Repositories;
public interface IBaseDataRepository
{
    Task<List<CityDbEntity>> GetAllCities(CancellationToken cancellationToken);
}
