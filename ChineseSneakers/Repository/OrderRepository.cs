using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;

namespace ChineseSneakers.Repository;

public class OrderRepository : IOrder
{
    private readonly MyAppDbContext _myAppDbContext;
    private readonly ShopCartModel _shopСartModel;

    public OrderRepository(MyAppDbContext myAppDbContext, ShopCartModel shopСartModel)
    {
        _myAppDbContext = myAppDbContext;
        _shopСartModel = shopСartModel;
    }

    public void CreateOrder(OrderModel orderModel)
    {
        orderModel.OrderTime = DateTime.Now;
        _myAppDbContext.OrderModel.Add(orderModel);
        _myAppDbContext.SaveChanges();

        var items = _shopСartModel.GetShopCartItemModels();

        foreach (var i in items)
        {
            var pm = new PaymentModel()
            {
                SneakersId = i.SneakersModel.Id,
                PaymentId = orderModel.Id,
                Price = i.SneakersModel.Price
            };
            _myAppDbContext.PaymentModel.Add(pm);
        }
        _myAppDbContext.SaveChanges();
    }
}