using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetDishes();
        Task<Dish> GetDish(string id);
        Task<IEnumerable<Dish>> GetDishByName(string name);
        Task<IEnumerable<Dish>> GetDishByCategory(string categoryName);

        Task CreateDish(Dish dish);
        Task<bool> UpdateDish(Dish dish);
        Task<bool> DeleteDish(string id);

       

    }
}
