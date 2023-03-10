using System.ComponentModel.DataAnnotations.Schema;

namespace NewPizzaDb.Data;

[Table(nameof(PizzaIngredient))]
public class PizzaIngredient
{
    public int Id { get; set; }
    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; } = null!;
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = null!;
}
