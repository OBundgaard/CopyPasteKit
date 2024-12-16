using API.Contexts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;


namespace API.Repositories;

public class MyClassRepository : IRepository<MyClass>
{
    private readonly MyDbContext db;
    private readonly AsyncRetryPolicy retryPolicy;

    public MyClassRepository(MyDbContext context)
    {
        db = context;
        retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    public async Task<MyClass> Post(MyClass entry)
    {
        return await retryPolicy.ExecuteAsync(async () =>
        {
            // Post, save, and return
            await db.MyObjects.AddAsync(entry);
            await db.SaveChangesAsync();
            return entry;
        });
    }

    public async Task<MyClass?> Get(int id)
    {
        return await retryPolicy.ExecuteAsync(async () =>
        {
            // Get and return
            var myObject = await db.MyObjects.FindAsync(id);
            return myObject;
        });
    }

    public async Task<IEnumerable<MyClass>> GetAll()
    {
        return await retryPolicy.ExecuteAsync(async () =>
        {
            // Get all and return
            var myObjects = await db.MyObjects.ToListAsync();
            return myObjects;
        });
    }

    public async Task<MyClass> Put(MyClass entry)
    {
        return await retryPolicy.ExecuteAsync(async () =>
        {
            // Update, save, and return
            var myObject = await db.MyObjects.FindAsync(entry);

            myObject!.Name = entry.Name;
            
            await db.SaveChangesAsync();
            return myObject;
        });
    }

    public async Task Delete(int id)
    {
        await retryPolicy.ExecuteAsync(async () =>
        {
            // Get and verify existence
            var myObject = await db.MyObjects.FindAsync(id);
            if (myObject == null)
                return;

            // Delete and save
            db.MyObjects.Remove(myObject);
            await db.SaveChangesAsync();
        });
    }
}
