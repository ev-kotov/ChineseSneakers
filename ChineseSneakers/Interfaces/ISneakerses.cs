using ChineseSneakers.Models;

namespace ChineseSneakers.Interfaces;

public interface ISneakerses
{
    IEnumerable<SneakersModel> SneakersModels { get; }
    IEnumerable<SneakersModel> GetFavoriteSneakersModels { get; }
    SneakersModel GetSneakersModel(int id);
}