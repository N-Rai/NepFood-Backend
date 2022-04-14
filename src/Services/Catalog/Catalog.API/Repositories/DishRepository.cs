using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class DishRepository: IDishRepository
    {
        private readonly ICatalogContext _context;
        public DishRepository(ICatalogContext 
            context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }    

        public async Task<IEnumerable<Dish>> GetDishes()
        {
            return await _context.Dishes.Find(p => true).ToListAsync();
        }

        public async Task<Dish> GetDish(string id)
        {
            return await _context.Dishes.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Dish>> GetDishByName(string name)
        {
            FilterDefinition<Dish> filter = Builders<Dish>.Filter.Eq(p => p.Name, name);
            return await _context.Dishes.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetDishByCategory(string categoryName)
        {
            FilterDefinition<Dish> filter = Builders<Dish>.Filter.Eq(p => p.Category, categoryName);
            return await _context.Dishes.Find(filter).ToListAsync();
        }
        public async Task CreateDish(Dish dish)
        {
            await _context.Dishes.InsertOneAsync(dish);

        }
        public async Task<bool> UpdateDish(Dish dish)
        {
            var updateResult = await _context.Dishes.ReplaceOneAsync(filter: g => g.Id == dish.Id, replacement: dish);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteDish(string id)
        {
            FilterDefinition<Dish> filter = Builders<Dish>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context.Dishes.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

    }
}
