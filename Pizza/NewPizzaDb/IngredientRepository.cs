using Microsoft.EntityFrameworkCore;

namespace NewPizzaDb;

public class IngredientRepository
{
    public void Show()
    {
        using var dbContext = new AppDbContext();

        foreach (var item in dbContext.Ingredients)
        {
            Console.WriteLine(item.Name);
        }
    }

    public void ShowSingle(int id)
    {
        using var dbContext = new AppDbContext();
        // include to get into table 
            // thenInclude makes it go into the Included table to move inner
        
        var data = dbContext.Pizzas
            .Include(x => x.Ingredient)
                .ThenInclude(x => x.Ingredient)
            .SingleOrDefault(x => x.Id == id)
            ;

        foreach (var i in data.Ingredient)
        {
            Console.WriteLine($"\t{i.Ingredient.Name}");
        }
    }

    public void IngredientsUsed()
    {
        using var dbContext = new AppDbContext();

        foreach (var item in dbContext.Ingredients.Include(x => x.Pizza))
        {
            Console.WriteLine($"{item.Name}, {item.Pizza.Count()}");
        }
    }
    
    private void PrintData(){}
}