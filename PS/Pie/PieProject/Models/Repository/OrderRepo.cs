namespace PieProject.Models.Repository;

public class OrderRepo(PieProjectDbContext dbContext, IShoppingCartRepo shoppingCart) : IOrderRepo
{
    public void CreateOrder(Order order)
    {
        ICollection<ShoppingCartItem>? shoppingCartItems = shoppingCart.ShoppingCartItems;
        order.OrderTotal = shoppingCart.GetShoppingCartTotal();

        if (shoppingCartItems != null)
        {
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                OrderDetail orderDetail = new()
                {
                    Order = order,
                    Pie = shoppingCartItem.Pie,
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price,
                };
                order.OrderDetails.Add(orderDetail);
            }

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

        }
    }
}
