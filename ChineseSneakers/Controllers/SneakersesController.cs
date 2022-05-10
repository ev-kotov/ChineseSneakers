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
    [Route("Sneakerses/List/{category}")]
    public IActionResult List(string category)
    {
        string _category = category;
        IEnumerable<SneakersModel>? sneakerses = null;
        string currCategory = "";
        
        if(string.IsNullOrEmpty(category)) // выводим все кроссы
        {
            sneakerses = _sneakerses.SneakersModels.OrderBy(sm => sm.Id);
        }
        else
        {
            if(string.Equals("running",category,StringComparison.OrdinalIgnoreCase))
            {
                sneakerses = _sneakerses.SneakersModels.Where(sm => sm.SneakersCategoryModel.Name.Equals("Беговые")).OrderBy(sm => sm.Id);
                currCategory = "Беговые";
            }
        
            if(string.Equals("usually",category, StringComparison.OrdinalIgnoreCase))
            {
                sneakerses = _sneakerses.SneakersModels.Where(sm => sm.SneakersCategoryModel.Name.Equals("Повседневные")).OrderBy(sm => sm.Id);
                currCategory = "Повседневные";
            }
        
            if(string.Equals("basketball",category, StringComparison.OrdinalIgnoreCase))
            {
                sneakerses = _sneakerses.SneakersModels.Where(sm => sm.SneakersCategoryModel.Name.Equals("Баскетбол")).OrderBy(sm => sm.Id);
                currCategory = "Баскетбол";
            }
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
