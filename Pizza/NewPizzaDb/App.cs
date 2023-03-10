namespace NewPizzaDb;
public class App
{
    public void Run()
    {
        var ingredientsRepo = new IngredientRepository();
        
        ingredientsRepo.ShowSingle(4);

        // var pizzaRepository = new PizzaRepository();
        //
        // if (!pizzaRepository.HasData())
        // {
        //     pizzaRepository.GeneratePizza();
        // }
        //
        // pizzaRepository.Show();
    }
}