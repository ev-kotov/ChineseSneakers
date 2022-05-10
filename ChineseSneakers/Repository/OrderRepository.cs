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
        _myAppDbContext.OrderModel.Add(orderModel); // добавить заказ
        _myAppDbContext.SaveChanges();

        var items = _shopСartModel.GetShopCartItemModels(); // получить все товары корзины

        foreach (var i in items)
        {
            var orderDetailModel = new OrderDetailModel()
            {
                SneakersId = i.SneakersModel.Id,
                OrderId = orderModel.Id,
                Price = i.SneakersModel.Price
            };
            _myAppDbContext.PaymentModel.Add(orderDetailModel); // добавим в БД
        }
        _myAppDbContext.SaveChanges();
    }
}