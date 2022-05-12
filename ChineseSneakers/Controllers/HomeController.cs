using System.Diagnostics;
using ChineseSneakers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ChineseSneakers.Models;
using ChineseSneakers.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChineseSneakers.Controllers;

public class HomeController : Controller
{
    private readonly ISneakerses _sneakerses;
    private readonly MyAppDbContext _myAppDbContext;

    public HomeController(ISneakerses sneakerses, MyAppDbContext myAppDbContext)
    {
        _sneakerses = sneakerses;
        _myAppDbContext = myAppDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string empSearch)
    {
        ViewData["GetEmployeeDetails"] = empSearch;
        var empQuery = from sm in _myAppDbContext.SneakersModel select  sm; 
        if (!string.IsNullOrEmpty(empSearch))
        {
            empQuery = empQuery.Where(sm =>
                sm.Name.Contains(empSearch) || sm.SneakersCategoryModel.Name.Contains(empSearch));
        }

        var favSneakers = new HomeViewModel()
        {
            FavoriteSneakerses = await empQuery.AsNoTracking().ToListAsync()
        };
        return View(favSneakers);
    }
    public IActionResult Index()
    {
        var favSneakers = new HomeViewModel
        {
            FavoriteSneakerses = _sneakerses.FavoriteSneakersModels
        };
        return View(favSneakers);
    }
}