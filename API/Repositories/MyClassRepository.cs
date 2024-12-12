using API.Contexts;
using API.Models;
using Microsoft.EntityFrameworkCore;


namespace API.Repositories;

public class MyClassRepository : IRepository<MyClass>
{
    private readonly MyDbContext db;

    public MyClassRepository(MyDbContext context)
    {
        db = context;
    }

    public async Task<MyClass> Post(MyClass entry)
    {
        // Post, save, and return
        await db.MyObjects.AddAsync(entry);
        await db.SaveChangesAsync();
        return entry;
    }

    public async Task<MyClass?> Get(int id)
    {
        // Get and return
        var myObject = await db.MyObjects.FindAsync(id);
        return myObject;
    }

    public async Task<IEnumerable<MyClass>> GetAll()
    {
        // Get all and return
        var myObjects = await db.MyObjects.ToListAsync();
        return myObjects;
    }

    public async Task<MyClass> Put(MyClass entry)
    {
        // Update, save, and return
        var myObject = db.Update(entry).Entity;
        await db.SaveChangesAsync();
        return myObject;
    }

    public async Task Delete(int id)
    {
        // Get and verify existence
        var myObject = await db.MyObjects.FindAsync(id);
        if (myObject == null)
            return;

        // Delete and save
        db.MyObjects.Remove(myObject);
        await db.SaveChangesAsync();
    }
}
