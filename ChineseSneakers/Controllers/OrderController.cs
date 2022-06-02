using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSneakers.Controllers;

public class OrderController : Controller
{
    private readonly IOrder _iOrder;
    private readonly ShopCartModel _shopCartModel;
    private readonly ILogger<OrderController> _logger;
    private readonly Service _service;

    public OrderController(IOrder iOrder, ShopCartModel shopCartModel, Service service)
    {
        _iOrder = iOrder;
        _shopCartModel = shopCartModel;
        _service = service;
    }

    public IActionResult CheckOut() // Функция IActionResult позволяет принимать данные
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CheckOut(OrderModel orderModel) // принимаем только post
    {
        _shopCartModel.ShopCartItemModels = _shopCartModel.GetShopCartItemModels(); // передаем товары в переменную
        
        if(_shopCartModel.ShopCartItemModels.Count == 0)
        {
            ModelState.AddModelError("","В корзине отсутствуют товары !");
        }

        if (ModelState.IsValid) // все проверки пройдены?
        {
            _iOrder.CreateOrder(orderModel); // создаем заказ
            _service.SendEmail(orderModel);
            return RedirectToAction("Complete");
        }
        return View(orderModel); // перезагрузить страницу заказа, т.к. проверки не пройдены
    }
    public ViewResult Complete()
    {
        ViewBag.Message = "Заказ успешно обработан. Ожидайте подтверждения.";
        return View();
    }
}