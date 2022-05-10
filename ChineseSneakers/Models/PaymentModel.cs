namespace ChineseSneakers.Models;

public class PaymentModel
{
    public int Id { get; set; }
    public int SneakersId { get; set; }
    
    public int PaymentId { get; set; }
    
    public double Price { get; set; }
    
    public virtual SneakersModel SneakersModel  { get; set; }
    public virtual OrderModel OrderModel { get; set; }
}