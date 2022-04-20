using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;

namespace ChineseSneakers.Repository;

public class OrderRepository : IOrder
{
    private readonly AppDbContext _appDbContext;
    private readonly ShoppingСart _shoppingСart;

    public OrderRepository(AppDbContext appDbContext, ShoppingСart shoppingСart)
    {
        _appDbContext = appDbContext;
        _shoppingСart = shoppingСart;
    }

    public void CreateOrder(Order order)
    {
        order.OrderTime = DateTime.Now;
        _appDbContext.Order.Add(order);
        _appDbContext.SaveChanges();

        var item = _shoppingСart.ListShoppingItems();

        foreach (var el in item)
        {
            var 
        }
    }
}