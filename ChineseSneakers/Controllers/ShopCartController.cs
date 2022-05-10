using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;
using ChineseSneakers.Repository;
using ChineseSneakers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSneakers.Controllers;

public class ShopCartController : Controller
{
    private readonly ISneakerses _sneakerses;
    private readonly ShopCartModel _shopCartModel;
    public ShopCartController(ISneakerses sneakerses, ShopCartModel shopCartModel)
    {
        _sneakerses = sneakerses;
        _shopCartModel = shopCartModel;
    }

    public ViewResult Index()
    {
        _shopCartModel.ShopCartItemModels = _shopCartModel.GetShopCartItemModels();
        var obj = new ShopCartViewModel
        {
            ShopCartModel = _shopCartModel
        };

        return View(obj);
    }
    
    public RedirectToActionResult AddToCart(int id)
    {
        var sneakersModel = _sneakerses.SneakersModels.FirstOrDefault(sm => sm.Id == id);
        if (sneakersModel != null)
        {
            _shopCartModel.AddToCart(sneakersModel);
        }
        return RedirectToAction("Index");
    }
}