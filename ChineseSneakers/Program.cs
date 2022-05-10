using ChineseSneakers;
using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;
using ChineseSneakers.Repository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Connection string 'ConnectionString' not found.")));

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("DataProtectionKeys"));

builder.Services.AddTransient<ISneakerses, SneakersesRepository>();
builder.Services.AddTransient<ISneakersCategory, SneakersCategoryRepository>();
builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCartModel.GetShopCartModel(sp));
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    MyAppDbContext context = scope.ServiceProvider.GetRequiredService<MyAppDbContext>();
    DBObjects.Initial(context);
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default", // главная страница
    // По-умолчанию (если не указан иной адрес): Контроллер - Home, метод контроллера - Index
    // По-умолчанию необязательный - id
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "categoryFilter",
    pattern: "{controller=Sneakers}/{action=List}/{category?}");

app.Run();