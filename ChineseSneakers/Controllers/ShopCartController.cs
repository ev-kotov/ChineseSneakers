using System.Security.Cryptography.X509Certificates;
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

    public ViewResult Index(bool coincidence = false)
    {
        ShopCartViewModel ff = new ShopCartViewModel()
        {
            ShopCartItemModels = _shopCartModel.GetShopCartItemModels()
        };

        ViewBag.coincidence = coincidence;
        
        return View(ff);
    }
    
    public RedirectToActionResult AddToCart(int id)
    {
        bool coincidence = false;

        if (_sneakerses.SneakersModels.FirstOrDefault(model => model.Id == id) != null)
        {
            _shopCartModel.ShopCartItemModels = _shopCartModel.GetShopCartItemModels();

            foreach (var scm in _shopCartModel.ShopCartItemModels)
            {
                if (scm.SneakersModel.Id == id)
                {
                    coincidence = true;
                    break;
                }
            }
            
            if(!coincidence)
                _shopCartModel.AddToCart(_sneakerses.SneakersModels.FirstOrDefault(i=>i.Id==id));
        }

        if (coincidence)
        {
            return RedirectToAction("Index", new {coincidence = true});
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
    public RedirectToActionResult DeleteWithoutCart(int id)
    {
        _shopCartModel.DeleteWithoutCart(id);
        return RedirectToAction("Index");
    }
}