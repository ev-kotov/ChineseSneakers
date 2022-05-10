using ChineseSneakers.Models;

namespace ChineseSneakers.Interfaces;

public interface ISneakersCategory
{
    IEnumerable<SneakersCategoryModel> SneakersModelsCategory { get; }
}