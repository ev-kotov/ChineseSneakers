namespace ChineseSneakers.Models;

public class ShopCartItemModel // товар в корзине покупок
{
    public int Id { get; set; }
    public SneakersModel SneakersModel { get; set; }
    public double Price { get; set; }
    public string ShopCartId { get; set; }
}