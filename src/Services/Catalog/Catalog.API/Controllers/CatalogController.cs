using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IDishRepository _repository;
        private readonly ILogger<CatalogController> logger;

        public CatalogController(IDishRepository repository, ILogger<CatalogController> _logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Dish>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            var dishes = await _repository.GetDishes();   
            //var dishes = await dishService.GetDishes();
            return Ok(dishes);
        }

        [HttpGet("{id:length(24)}", Name = "GetDish")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Dish), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Dish>> GetDishById(string id)
        {
            var dish = await _repository.GetDish(id);
            if (dish is null)
            {
                logger.LogError($"Dish with id: {id}, not found.");
                return NotFound();
            }
            return Ok(dish);
        }

        [Route("[action]/{category}", Name = "GetDishByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(Dish), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishByCategory(string categoryName)
        {
            var dishes = await _repository.GetDishByCategory(categoryName);
            return Ok(dishes);
        }

        [Route("[action]/{name}", Name = "GetDishByName")]
        [HttpGet]
        [ProducesResponseType(typeof(Dish), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishByName(string name)
        {
            var dish = await _repository.GetDishByName(name);
            if (dish is null)
            {
                logger.LogError($"Dish with name: {name}, not found.");
                return NotFound();
            }
            return Ok(dish);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Dish), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Dish>> CreateDish([FromBody] Dish dish)
        {
            if(dish.Name is null || dish.Price == 0)
            {
                return BadRequest();
            }

            await _repository.CreateDish(dish);

            return CreatedAtRoute("GetDish", new { id = dish.Id }, dish);

        }

        [HttpPut]
        [ProducesResponseType(typeof(Dish), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDish([FromBody] Dish dish)
        {
            if (dish.Name is null || dish.Price == 0)
            {
                return BadRequest();
            }

            return Ok(await _repository.UpdateDish(dish));            

        }

        [HttpDelete("{id:length(24)}", Name = "DeleteDish")]
        [ProducesResponseType(typeof(Dish), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDish(string id)
        {
            return Ok(await _repository.DeleteDish(id));

        }




    }
}
