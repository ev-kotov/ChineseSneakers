using System.Diagnostics;
using ChineseSneakers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ChineseSneakers.Models;
using ChineseSneakers.ViewModels;

namespace ChineseSneakers.Controllers;

public class HomeController : Controller
{
    private readonly ISneakerses _sneakerses;

    public HomeController(ISneakerses sneakerses) => _sneakerses = sneakerses;

    public IActionResult Index()
    {
        var favSneakers = new HomeViewModel
        {
            FavoriteSneakerses = _sneakerses.FavoriteSneakersModels
        };
        return View(favSneakers);
    }
}