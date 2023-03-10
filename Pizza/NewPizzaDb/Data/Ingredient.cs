using System.ComponentModel.DataAnnotations.Schema;

namespace NewPizzaDb.Data;

[Table(nameof(Ingredient))]
public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<PizzaIngredient> Pizza { get; set; } = new HashSet<PizzaIngredient>();
}