namespace PieProject.Models.Repository;

public interface IShoppingCartRepo
{
    void AddToCart(Pie pie);
    int RemoveFromCart(Pie pie);
    ICollection<ShoppingCartItem> GetShoppingCartItems();
    void ClearCart();
    decimal GetShoppingCartTotal();
    ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
}
