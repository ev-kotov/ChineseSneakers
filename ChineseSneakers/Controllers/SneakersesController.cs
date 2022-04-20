using ChineseSneakers.Interfaces;
using ChineseSneakers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSneakers.Controllers;

public class SneakersesController : Controller
{
    private readonly ISneakerses _sneakerses;
    private readonly ISneakersCategory _sneakersCategories;

    public SneakersesController(ISneakerses sneakerses, ISneakersCategory sneakersCategories)
    {
        _sneakerses = sneakerses;
        _sneakersCategories = sneakersCategories;
    }

    public IActionResult List()
    {
        ViewBag.Title = "Страница с кроссовками";
        var obj = new SneakersesViewModel();
        obj.Sneakerses = _sneakerses.SneakersModels;
        //obj.SneakersCategory = "Shoes";
        return View(obj);
    }

}
