using ChineseSneakers.Models;

namespace ChineseSneakers.Interfaces;

public interface ISneakersCategory
{
    IEnumerable<SneakersCategoryModel> SneakersCategoryModels { get; }
}