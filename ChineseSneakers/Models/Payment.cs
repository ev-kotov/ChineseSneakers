namespace ChineseSneakers.Models;

public class Payment
{
    public int Id { get; set; }
    public int PaymentID { get; set; }
    public int SneakersID { get; set; }
    public uint Price { get; set; }
}