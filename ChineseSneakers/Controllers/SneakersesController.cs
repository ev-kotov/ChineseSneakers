using System.Collections;
using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;
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

    [Route("Sneakerses/List")]
    [Route("Sneakerses/List/{url}")]
    public IActionResult List(string url)
    {
        IEnumerable<SneakersModel>? sneakerses = null;
        string currCategory = "Кроссовки";
        
        if(string.IsNullOrEmpty(url))
        {
            sneakerses = _sneakerses.SneakersModels.OrderBy(sm => sm.Price);
        }
        if(string.Equals("running",url,StringComparison.OrdinalIgnoreCase))
        {
            sneakerses = _sneakerses.SneakersModels.Where(sm => sm.SneakersCategoryModel.Name.Equals("Беговые")).OrderBy(sm => sm.Price);
        }
        
        if(string.Equals("usually",url, StringComparison.OrdinalIgnoreCase))
        {
            sneakerses = _sneakerses.SneakersModels.Where(sm => sm.SneakersCategoryModel.Name.Equals("Повседневные")).OrderBy(sm => sm.Price);
        }
        
        if(string.Equals("basketball",url, StringComparison.OrdinalIgnoreCase))
        {
            sneakerses = _sneakerses.SneakersModels.Where(sm => sm.SneakersCategoryModel.Name.Equals("Баскетбол")).OrderBy(sm => sm.Price);
        }
        
        var obj = new SneakersesViewModel()
        {
            Sneakerses = sneakerses,
            SneakersCategory = currCategory
        };

        ViewBag.Title = "Страница с кроссовками";
        
        return View(obj);
    }
}
