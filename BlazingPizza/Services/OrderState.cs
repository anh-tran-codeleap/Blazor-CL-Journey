namespace BlazingPizza.Services;

public class OrderState
{
    public bool ShowingConfigurePizzaDialog { get; private set; }
    public Pizza ConfiguringPizza {get; private set;}
    public Order Order {get; private set;} = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };
        ShowingConfigurePizzaDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigurePizzaDialog = false;
    }
    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza);
        ConfiguringPizza = null;

        ShowingConfigurePizzaDialog = false;
    }
    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }
}