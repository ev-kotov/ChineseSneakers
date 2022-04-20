using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;

namespace ChineseSneakers.Repository;

public class SneakersCategoriesRepository : ISneakersCategory
{
    private readonly MyAppDbContext _myAppDbContext;

    public SneakersCategoriesRepository(MyAppDbContext myAppDbContext)
    {
        _myAppDbContext = myAppDbContext;
    }

    public IEnumerable<SneakersCategoryModel> SneakersCategoryModels => _myAppDbContext.CategoryModel;
}