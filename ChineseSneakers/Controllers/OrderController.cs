using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSneakers.Controllers;

public class OrderController : Controller
{
    private readonly IOrder _iOrder;
    private readonly ShopCartModel _shopCartModel;
    
    public OrderController(IOrder iOrder, ShopCartModel shopCartModel)
    {
        _iOrder = iOrder;
        _shopCartModel = shopCartModel;
    }

    public IActionResult CheckOut() // Функция IActionResult позволяет принимать данные
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CheckOut(OrderModel orderModel)
    {
        _shopCartModel.ShopCartItemModels = _shopCartModel.GetShopCartItemModels();
        
        if(_shopCartModel.ShopCartItemModels.Count == 0)
        {
            ModelState.AddModelError("","Товары отсутствуют!");
        }
  
        _iOrder.CreateOrder(orderModel);
        return RedirectToAction("Complete");
    }
    public ViewResult Complete()
    {
        ViewBag.Message = "Заказ успешно обработан";
        return View();
    }
}