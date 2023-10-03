using System.Text.Json;
using Cache_Maktab97.Infrastructure.Cache;
using Cache_Maktab97.Infrastructure.Cache.InMemoryCache;
using Cache_Maktab97.Infrastructure.Cache.RedisCache;
using Cache_Maktab97.Infrastructure.EfCore.Entities;
using Cache_Maktab97.Infrastructure.EfCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Cache_Maktab97.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBaseDataRepository _baseDataRepository;
        private readonly IInMemoryCacheService _inMemoryCacheService;
        private readonly IDistributedCache _distributedCache;
        private readonly IRedisCacheServices _redisCacheServices;

        public IndexModel(IBaseDataRepository baseDataRepository,
            IInMemoryCacheService inMemoryCacheService,
            IDistributedCache distributedCache, IRedisCacheServices redisCacheServices)
        {
            _baseDataRepository = baseDataRepository;
            _inMemoryCacheService = inMemoryCacheService;
            _distributedCache = distributedCache;
            _redisCacheServices = redisCacheServices;
        }

        public async Task OnGet()
        {

            if (!_redisCacheServices.HasCache(CacheKey.Cities))
            {
                var result = await _baseDataRepository.GetAllCities(default);
                _redisCacheServices.SetSliding(CacheKey.Cities,result,10);
            }
        }

    }
}
