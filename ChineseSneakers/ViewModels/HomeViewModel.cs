using ChineseSneakers.Models;

namespace ChineseSneakers.ViewModels;

public class HomeViewModel
{
    public IEnumerable<SneakersModel>? FavoriteSneakerses { get; set; }
}