using Microsoft.EntityFrameworkCore;
using NewPizzaDb.Data;

namespace NewPizzaDb;

public class PizzaRepository
{
    public bool HasData()
    {
        using var dbContext = new AppDbContext();
        return dbContext.Pizzas.Any();
    }
    
    public void GeneratePizza()
    {
        using var dbContext = new AppDbContext();
        var dbContextCount = dbContext.Ingredients.Count();
        var rnd = new Random();
        for (int i = 0; i < 20; i++)
        {
            int num = rnd.Next(2, 7);
            var pizz = new Pizza
            {
                Name = Guid.NewGuid().ToString(),
                Sauce = (Sauce)rnd.Next(1, 4),
            };
            dbContext.Add(pizz);

            for (int j = 0; j < num; j++)
            {
                var ing = new PizzaIngredient()
                {
                    IngredientId = rnd.Next(1, dbContextCount),
                };
                pizz.Ingredient.Add(ing);
            }

            dbContext.SaveChanges();
        }
    }
    
    public void Show()
    {
        using var dbContext = new AppDbContext();

        var pizzas = dbContext
            .Pizzas
            .Include(x => x.Ingredient)
            .ThenInclude(x => x.Ingredient);

        foreach (var item in pizzas)
        {
            Console.WriteLine(item.Name + " " + item.Sauce);

            foreach (var i in item.Ingredient)
            {
                Console.WriteLine($"\t{i.Ingredient.Name}");
            }
        }
    }
}