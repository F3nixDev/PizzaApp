using System.ComponentModel.DataAnnotations.Schema;

namespace NewPizzaDb.Data;

[Table(nameof(Pizza))]
public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Sauce Sauce { get; set; }
    public ICollection<PizzaIngredient> Ingredient { get; set; } = new HashSet<PizzaIngredient>();
}

public enum Sauce
{
    None = 1,
    Tomato = 2,
    Cream = 3,
}
