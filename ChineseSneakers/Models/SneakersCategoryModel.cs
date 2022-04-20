namespace ChineseSneakers.Models;

public class SneakersCategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    private List<SneakersModel> SneakersCollection { get; set; }
}