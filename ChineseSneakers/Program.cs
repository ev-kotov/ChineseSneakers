using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ISneakerses, SneakersesRepository>();
builder.Services.AddTransient<ISneakersCategory, SneakersCategoriesRepository>();
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Connection string 'ConnectionString' not found.")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    MyAppDbContext context = scope.ServiceProvider.GetRequiredService<MyAppDbContext>();
    DBObjects.Initial(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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