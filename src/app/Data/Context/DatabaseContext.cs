namespace RecipeBook.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using RecipeBook.Data.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        try
        {
            if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
            {
                if (!databaseCreator.CanConnect())
                {
                    databaseCreator.Create();
                }

                if (!databaseCreator.HasTables())
                {
                    Database.Migrate();
                    if (Users.CountAsync().Result == 0)
                    {
                        Users.Add(User.CreateBuilder()
                            .SetUsername("admin")
                            .SetPassword("Pa$$w0rd")
                            .SetEmail("admin@admin.com")
                            .Build());
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public DatabaseContext()
        : this(new DbContextOptionsBuilder<DatabaseContext>()
            .Options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Recipe> Recipes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(p => p.Username)
            .IsUnique(true);
    }
}
