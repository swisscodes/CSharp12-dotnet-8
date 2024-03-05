namespace PieProject.Models.Repository;

public interface IShoppingCartRepo
{
    void AddToCart(Pie pie);
    int RemoveFromCart(Pie pie);
    IEnumerable<ShoppingCartItem> GetShoppingCartItems();
    void ClearCart();
    decimal GetShoppingCartTotal();
    IEnumerable<ShoppingCartItem>? ShoppingCartItems { get; set; }
}
