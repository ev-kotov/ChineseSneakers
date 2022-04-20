namespace ChineseSneakers.Models;

public class SneakersModel
{
    public int Id { get; set; }
    public string Article { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public double Size { get; set; }
    public string Female { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Image { get; set; }
    public double Price { get; set; }
    public bool IsFavorite { get; set; }
    public bool Available { get; set; }
        
    public int CategoryId { get; set; }
    public SneakersCategoryModel SneakersCategory { get; set; }
}