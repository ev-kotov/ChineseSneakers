using ChineseSneakers.Interfaces;
using ChineseSneakers.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseSneakers.Repository;

public class SneakersesRepository : ISneakerses
{
    private readonly MyAppDbContext _myAppDbContext;

    public SneakersesRepository(MyAppDbContext myAppDbContext) => _myAppDbContext = myAppDbContext;

    public IEnumerable<SneakersModel> SneakersModels => 
        _myAppDbContext.SneakersModel.Include(cm => cm.SneakersCategoryModel);

    public IEnumerable<SneakersModel> FavoriteSneakersModels =>
        _myAppDbContext.SneakersModel.Where(sm => sm.IsFavorite).Include(sm => sm.SneakersCategoryModel);

    public SneakersModel GetSneakersModel(int id) =>
        _myAppDbContext.SneakersModel.FirstOrDefault(sm => sm.Id == id);
}