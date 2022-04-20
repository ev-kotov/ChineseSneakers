using ChineseSneakers.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseSneakers;

public class AppDbContext :DbContext
{
    public DbSet<Order> Order { get; set; }
}