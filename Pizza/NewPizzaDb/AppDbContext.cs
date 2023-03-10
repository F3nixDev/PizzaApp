using Microsoft.EntityFrameworkCore;
using NewPizzaDb.Data;

namespace NewPizzaDb;

internal class AppDbContext : DbContext
{ 
    public DbSet<Pizza> Pizzas { get; set; } = null!;

    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("User ID=postgres;Password=MasterPassword;Host=localhost;Port=5432;Database=NewPizzaDb;");
    }
}
