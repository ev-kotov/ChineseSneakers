using ChineseSneakers.Models;

namespace ChineseSneakers;

public class DBObjects
{
    public static void Initial(MyAppDbContext context)
    {
        if (!context.SneakersCategoryModel.Any())
            context.SneakersCategoryModel.AddRange(Categories.Select(c => c.Value));

        if (!context.SneakersModel.Any())
        {
            context.AttachRange(
                new SneakersModel
                {
                    Article = "979419120039",
                    Name = "JLIN2 LIGHT",
                    Brand = "Xtep",
                    Size = 44,
                    Female = "Man",
                    ShortDescription = "Новинка! Очень мягкие",
                    LongDescription = "",
                    Image = "/img/XTEP JLIN2 LIGHT.webp",
                    Price = 11224.30,
                    IsFavorite = true,
                    Available = true,
                    SneakersCategoryModel = Categories["Повседневные"]
                },
                new SneakersModel
                {
                    Article = "822218084-8",
                    Name = "BADAO 3.0",
                    Brand = "ANTA",
                    Size = 37,
                    Female = "Woman",
                    ShortDescription = "",
                    LongDescription = "",
                    Image = "/img/ANTA BADAO 3.0.webp",
                    Price = 11360,
                    IsFavorite = false,
                    Available = false,
                    SneakersCategoryModel = Categories["Повседневные"]
                },
                new SneakersModel
                {
                    Article = "ARRS003",
                    Name = "SHADOW ESSENTIAL BOOM JIANG",
                    Brand = "Li-Ning",
                    Size = 42,
                    Female = "Man",
                    ShortDescription = "Суперскоростные кросcы",
                    LongDescription = "",
                    Image = "/img/Li-Ning-SHADOW-ESSENTIAL-BOOM-JIANG.webp",
                    Price = 10370,
                    IsFavorite = true,
                    Available = true,
                    SneakersCategoryModel = Categories["Беговые"]
                },
                new SneakersModel
                {
                    Article = "00001",
                    Name = "Q-KUNGFU PRO",
                    Brand = "Qiaodan",
                    Size = 41,
                    Female = "Man",
                    ShortDescription = "",
                    LongDescription = "",
                    Image = "/img/1609322654443.png",
                    Price = 12000,
                    IsFavorite = true,
                    Available = false,
                    SneakersCategoryModel = Categories["Беговые"]
                },
                new SneakersModel
                {
                    Article = "00002",
                    Name = "LooserJet",
                    Brand = "Peak",
                    Size = 43,
                    Female = "Man",
                    ShortDescription = "",
                    LongDescription = "",
                    Image = "/img/Peak LooserJet.webp",
                    Price = 15000,
                    IsFavorite = true,
                    Available = true,
                    SneakersCategoryModel = Categories["Беговые"]
                },
                new SneakersModel
                {
                    Article = "00003",
                    Name = "Part1",
                    Brand = "361",
                    Size = 40,
                    Female = "Man",
                    ShortDescription = "",
                    LongDescription = "",
                    Image = "/img/361-2.webp",
                    Price = 7000,
                    IsFavorite = false,
                    Available = true,
                    SneakersCategoryModel = Categories["Беговые"]
                });

        }
        context.SaveChanges();
    }

    private static Dictionary<string, SneakersCategoryModel> _categories;

    private static Dictionary<string, SneakersCategoryModel> Categories
    {
        get
        {
            if (_categories == null)
            {
                var list = new SneakersCategoryModel[]
                {
                    new() {Name = "Беговые", Description = "Обувь для активных людей"},
                    new() {Name = "Повседневные", Description = "Повседневная обувь для города"},
                    new() {Name = "Баскетбол", Description = "Кроссовки для парения"}
                };

                _categories = new Dictionary<string, SneakersCategoryModel>();
                foreach (var i in list)
                {
                    _categories.Add(i.Name, i);
                }
            }
            return _categories;
        }
    }
}