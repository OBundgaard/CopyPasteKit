using API.Models;
using Microsoft.Extensions.Caching.Memory;

namespace API.Repositories;

public class MyClassCachedRepository : IRepository<MyClass>
{
    private readonly MyClassRepository repository;
    private readonly IMemoryCache cache;

    public MyClassCachedRepository(MyClassRepository repository, IMemoryCache cache)
    {
        this.repository = repository;
        this.cache = cache;
    }

    public async Task<MyClass> Post(MyClass entry)
    {
        // Do not cache
        return await repository.Post(entry);
    }

    public async Task<MyClass?> Get(int id)
    {
        string key = $"MyClass_{id}";

        return await cache.GetOrCreateAsync(key, async entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
            return await repository.Get(id);
        });
    }

    public async Task<IEnumerable<MyClass>> GetAll()
    {
        // Do not cache
        return await repository.GetAll();
    }

    public async Task<MyClass> Put(MyClass entry)
    {
        // Do not cache
        return await repository.Put(entry);
    }

    public async Task Delete(int id)
    {
        // Do not cache
        await repository.Delete(id);
    }
}
