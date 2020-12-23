using DishesTask.Filter;
using DishesTask.Models;
using DishesTask.Workers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DishesTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        /// <summary>
        /// GET-Request - Zum abrufen aller Produkte.
        /// </summary>
        /// <param name="filter">Enthält die entsprechenden Filterkriterien.</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Dishes> Get([FromQuery] GetFilter filter)
        {
            var res = new GetAllDishesWorker().DoWork(filter);
            return res;
        }

        /// <summary>
        /// POST-Request - Zum erstellen neuer Produkte.
        /// </summary>
        /// <param name="dishList"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] List<Dishes> dishList)
        {
            if (new CreateDishesWorker().DoWork(dishList))
            {
                return Ok("Products successfully created.");
            }
            return BadRequest("Error on Product creation.");
        }

        /// <summary>
        /// PUT-Request - zum bearbeiten bestehender Produkte.
        /// </summary>
        /// <param name="filter">Enthält die entsprechenden Filterkriterien.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromQuery] PutFilter filter)
        {
            if (filter.Id <= 0)
            {
                return BadRequest("Id can not be blank.");
            }

            if (filter.Id > 0)
            {
                if (new UpdateDishesWorker().DoWork(filter))
                {
                    return Ok($"Product with Id: {filter.Id} successfully updated.");
                }
            }
            return BadRequest("Product update failed.");
        }
    }
}
