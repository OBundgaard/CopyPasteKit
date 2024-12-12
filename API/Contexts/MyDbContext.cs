using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts;

public class MyDbContext : DbContext
{
    public DbSet<MyClass> MyObjects { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyClass>().HasKey(o => o.ID);
        modelBuilder.Entity<MyClass>().Property(o => o.ID).ValueGeneratedOnAdd();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while saving changes to the database.", ex);
        }
    }
}
