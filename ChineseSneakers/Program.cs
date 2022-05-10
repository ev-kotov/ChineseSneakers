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

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCartModel.GetShopCartModel(sp));

builder.Services.AddTransient<ISneakersCategory, SneakersCategoryRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    MyAppDbContext context = serviceScope.ServiceProvider.GetRequiredService<MyAppDbContext>();
    DBObjects.Initial(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();