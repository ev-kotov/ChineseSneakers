using ChineseSneakers.Models;

namespace ChineseSneakers.Interfaces;

public interface IOrder
{
    void CreateOrder(Order order);
}