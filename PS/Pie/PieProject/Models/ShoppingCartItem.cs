namespace PieProject.Models;

public class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }
    public required Pie Pie { get; set; }
    public int Amount { get; set; }
    public string? ShoppingCartId { get; set; }

}
