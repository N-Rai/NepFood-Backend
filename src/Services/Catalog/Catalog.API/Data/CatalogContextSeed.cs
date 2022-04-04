using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
         public static void SeedData(IMongoCollection<Dish> dishCollection)
        {
            bool existDish = dishCollection.Find(p => true).Any();
            if (!existDish)
            {
                dishCollection.InsertManyAsync(GetPreconfiguredDishes());
            }
        }

        private static IEnumerable<Dish> GetPreconfiguredDishes()
        {
            return new List<Dish>()
            {
               new Dish()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Butter Chicken",
                    ImageFile = "",
                    Description = "Aromatic golden chicken pieces in an incredible curry sauce.",                   
                    Price = 18,
                    SpicyLevel = "Mild"
                },
                new Dish()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Vindaloo",
                    ImageFile = "",
                    Description = "A standard element of Goan cuisine derived from the Portuguese carne de vinha d'alhos (meat in garlic marinade).",
                    Price = 16,
                    SpicyLevel = "High"
                },
                new Dish()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Lamb Roghanjosh",
                    ImageFile = "",
                    Description = "An indian lamb curry with a heady combination of intense spices in a creamy tomato curry sauce.",
                    Price = 18,
                    SpicyLevel = "Medium"
                },
                new Dish()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Paneer Butter Masala",
                    ImageFile = "",
                    Description = "A rich & creamy curry made with paneer, spices, onions, tomatoes, cashews and butter.",
                    Price = 18,
                    SpicyLevel = "Mild"
                },
                new Dish()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Chicken Madras",
                    ImageFile = "",
                    Description = "A madras curry is a fairly hot curry with a dark red thick sauce (the colour comes from the chillies and paprika).",
                    Price = 18,
                    SpicyLevel = "Mild"
                },
                new Dish()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Nepalese Momo",
                    ImageFile = "",
                    Description = "A dumpling made of all-purpose flour and filled with either meat or vegetables.",
                    Price = 10,
                    SpicyLevel = "Medium"
                }
            };
        }
    }
}
