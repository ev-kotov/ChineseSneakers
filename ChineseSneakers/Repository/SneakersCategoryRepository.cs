using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;

namespace ChineseSneakers.Repository;

public class SneakersCategoryRepository : ISneakersCategory
{
    private readonly MyAppDbContext _myAppDbContext;
    public SneakersCategoryRepository(MyAppDbContext myAppDbContext) => _myAppDbContext = myAppDbContext;
    public IEnumerable<SneakersCategoryModel> SneakersModelsCategory => _myAppDbContext.SneakersCategoryModel;
}