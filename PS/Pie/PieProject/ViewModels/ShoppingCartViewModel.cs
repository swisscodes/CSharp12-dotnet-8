using PieProject.Models;

namespace PieProject.ViewModels;

public class ShoppingCartViewModel(IEnumerable<ShoppingCartItem> shoppingCart, decimal cartTotal)
{
    public readonly IEnumerable<ShoppingCartItem> ShoppingCartItems = shoppingCart;
    public readonly decimal ShoppingCartTotal = cartTotal;
}
