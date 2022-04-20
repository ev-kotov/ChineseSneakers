using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;

namespace ChineseSneakers.Repository;

public class SneakersesRepository : ISneakerses
{
    private readonly MyAppDbContext _myAppDbContext;

    public SneakersesRepository(MyAppDbContext myAppDbContext)
    {
        _myAppDbContext = myAppDbContext;
    }

    public IEnumerable<SneakersModel> SneakersModels => 
        _myAppDbContext.SneakersModel.Include(c => c.SneakersCategory);

    public IEnumerable<SneakersModel> GetFavoriteSneakersModels =>
        _myAppDbContext.SneakersModel.Where(p => p.IsFavorite).Include(c => c.SneakersCategory);

    public SneakersModel GetSneakersModel(int id) =>
        _myAppDbContext.SneakersModel.FirstOrDefault(p => p.Id == id);
}