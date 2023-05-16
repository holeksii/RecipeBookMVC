namespace RecipeBook.Data.Context;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Models;

public class DatabaseContext : IdentityDbContext<User>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        try
        {
            if (Database.GetService<IDatabaseCreator>() is not RelationalDatabaseCreator databaseCreator)
            {
                return;
            }

            if (!databaseCreator.CanConnect())
            {
                databaseCreator.Create();
            }

            if (databaseCreator.HasTables())
            {
                return;
            }

            Database.Migrate();
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>()
            .HasIndex(p => p.UserName)
            .IsUnique(true);
    }
}
