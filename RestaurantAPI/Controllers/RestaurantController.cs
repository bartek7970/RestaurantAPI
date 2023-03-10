using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantController(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
       public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _dbContext
                .Restaurants
                .ToList();

            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
              var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(r => r.Id == id);

            if(restaurant == null)
            {
                return NotFound();
            }
            
                return Ok(restaurant);
            
        }
    }
}
