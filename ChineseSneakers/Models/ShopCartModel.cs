using Microsoft.EntityFrameworkCore;

namespace ChineseSneakers.Models;

public class ShopCartModel
{
    private readonly MyAppDbContext _myAppDbContext;

    public ShopCartModel(MyAppDbContext myAppDbContext) => _myAppDbContext = myAppDbContext;

    private string ShopCartId { get; set; }
    public List<ShopCartItemModel> ShopCartItemModels { get; set; }

    public static ShopCartModel GetShopCartModel(IServiceProvider service)
    {
        ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = service.GetService<MyAppDbContext>();
        
        string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", shopCartId);
        
        return new ShopCartModel(context) { ShopCartId = shopCartId };
    }
    
    public void AddToCart(SneakersModel sneakersModel)
    {
        _myAppDbContext.ShopCartItemModel.Add(new ShopCartItemModel()
        {
            ShopCartId = ShopCartId,
            SneakersModel = sneakersModel,
            Price = sneakersModel.Price
        });

        _myAppDbContext.SaveChanges();
    }
    
    public List<ShopCartItemModel> GetShopCartItemModels()
    {
        return _myAppDbContext.ShopCartItemModel.Where(scim => scim.ShopCartId == ShopCartId).Include(scim => scim.SneakersModel).ToList();
    }
    
    
}