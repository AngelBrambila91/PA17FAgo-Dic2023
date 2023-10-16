using Microsoft.EntityFrameworkCore;
// DbContext., DbcontextOptions
namespace WorkingWithEFCore;

public class Northwind : DbContext
{
    // These properties tell which tables are available
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
        string connection = $"Filename={path}";
        ConsoleColor backgoundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection : {connection}");
        ForegroundColor = backgoundColor;
        // Use The DB Motor
        optionsBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // FluentApi
        // 1.- use of modelBuilder
        // 2.- Entity to Use
        // 3.- Property to validate
        // 4.- Validate the shit out of that thing
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired()
        .HasMaxLength(15);

        if(Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }
    }
}