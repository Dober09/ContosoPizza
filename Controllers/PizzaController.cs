using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController() { }

        // get all action
        [HttpGet(Name = "pizza")]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // get by id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }



        // post action
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            // this code will save the pizza abd return result
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        //put action
        [HttpPut("{id}")]
        public IActionResult Updata(int id,Pizza pizza) {
            
            if(id == pizza.Id)
            {
                return BadRequest();
            }

            var existingPizza = PizzaService.Get(id);

            if(existingPizza is null)
            {
                return NotFound();
            }

            PizzaService.Update(pizza);

            return NoContent();
        }

        //delete action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //3
            var pizza = PizzaService.Get(id);

            if(pizza is null)
            {
                return NotFound();
            }

            PizzaService.Delete(id);

            return NoContent();

        }

    }
}
