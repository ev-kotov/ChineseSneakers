namespace ChineseSneakers.Models;

public sealed class OrderDetailModel // Подробности заказа
{
    public int Id { get; set; }
    public int SneakersId { get; set; }
    public int OrderId { get; set; }
    public double Price { get; set; }
    public SneakersModel? SneakersModel  { get; set; }
    public OrderModel? OrderModel { get; set; }
}