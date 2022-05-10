using ChineseSneakers.Models;

namespace ChineseSneakers.ViewModels;

public class SneakersesViewModel
{
    public IEnumerable<SneakersModel>? Sneakerses { get; set; }
    public string SneakersCategory { get; set; }
}