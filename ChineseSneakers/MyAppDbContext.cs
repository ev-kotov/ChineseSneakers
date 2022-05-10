using ChineseSneakers.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseSneakers;

public class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
    {
    }
    public DbSet<SneakersModel> SneakersModel { get; set; }
    public DbSet<SneakersCategoryModel> SneakersCategoryModel { get; set; }
    public DbSet<ShopCartItemModel> ShopCartItemModel { get; set; }
    public DbSet<OrderModel> OrderModel { get; set; }
    public DbSet<OrderDetailModel> PaymentModel { get; set; }
}