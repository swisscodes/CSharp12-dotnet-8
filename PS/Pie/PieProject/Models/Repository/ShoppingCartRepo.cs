using Microsoft.EntityFrameworkCore;

namespace PieProject.Models.Repository;

public class ShoppingCartRepo(PieProjectDbContext context) : IShoppingCartRepo
{
    public string? ShoppingCartId { get; set; }
    public IEnumerable<ShoppingCartItem>? ShoppingCartItems { get; set; }


    public static ShoppingCartRepo GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        PieProjectDbContext context = services.GetService<PieProjectDbContext>()
            ?? throw new Exception("Error initializing");

        string cartId = session?.GetString("cartId") ?? Guid.NewGuid().ToString();
        session?.SetString("cartId", cartId);

        return new ShoppingCartRepo(context) { ShoppingCartId = cartId };
    }

    public void AddToCart(Pie pie)
    {
        ShoppingCartItem? shoppingCartItem = context.ShoppingCartItems.SingleOrDefault(s => s.ShoppingCartId == ShoppingCartId
            && s.Pie.PieId == pie.PieId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Pie = pie,
                Amount = 1
            };

            context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }

        context.SaveChanges();
    }

    public int RemoveFromCart(Pie pie)
    {
        ShoppingCartItem? shoppingCartItem = context.ShoppingCartItems.SingleOrDefault(s => s.ShoppingCartId == ShoppingCartId
           && s.Pie.PieId == pie.PieId);

        int localAmount = 0;

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        context.SaveChanges();
        return localAmount;
    }

    public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ??= [.. context.ShoppingCartItems
            .Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Pie)];
    }

    public void ClearCart()
    {
        var cartItems = context.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
        context.ShoppingCartItems.RemoveRange(cartItems);
        context.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        decimal total = context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            .Select(c => c.Pie.Price * c.Amount).Sum();

        return total;
    }

}
