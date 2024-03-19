using PieProject.Models;

namespace PieProject.ViewModels;

public class ShoppingCartViewModel(ICollection<ShoppingCartItem> shoppingCart, decimal cartTotal)
{
    public readonly ICollection<ShoppingCartItem> ShoppingCartItems = shoppingCart;
    public readonly decimal ShoppingCartTotal = cartTotal;
}
