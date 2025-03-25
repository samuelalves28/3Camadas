using Microsoft.EntityFrameworkCore;

namespace Data.Context;
public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
{
    public DbSet<T> GetDbSet<T>() where T : class => Set<T>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entityTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                t.IsPublic &&
                t.Namespace == "Business.Models");

        foreach (var type in entityTypes)
            modelBuilder.Entity(type);
    }
}
