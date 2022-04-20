using Microsoft.EntityFrameworkCore;

namespace ChineseSneakers;

public class MyAppDbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
    {
    }
    public DbSet<SneakersModel> SneakersModel { get; set; }
    public DbSet<SneakersCategoryModel> CategoryModel { get; set; }
}