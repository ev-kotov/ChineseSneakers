using ChineseSneakers.Models;

namespace ChineseSneakers.Interfaces;

public interface IOrder
{
    void CreateOrder(OrderModel orderModel);
}