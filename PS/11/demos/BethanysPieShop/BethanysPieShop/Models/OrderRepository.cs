namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BethanysPieShopDbContext bethanysPieShopDbContext, IShoppingCart shoppingCart)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _bethanysPieShopDbContext.Orders.Add(order);

            _bethanysPieShopDbContext.SaveChanges();
        }
    }
}
