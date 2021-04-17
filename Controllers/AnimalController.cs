#nullable enable
using System.Collections.Generic;
using cwiczenia3_zen_s19743.Model;
using cwiczenia3_zen_s19743.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia3_zen_s19743.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _service;

        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetSortedAnimals(string? orderBy = "name")
        {
            List<Animal> animals;
            try
            {
                animals = _service.GetSortedAnimals(orderBy);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(animals);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal newAnimal)
        {
            Animal animal = _service.AddAnimal(newAnimal);
            return Ok(animal);
        }

        [HttpPut]
        [Route("{animalId}")]
        public IActionResult UpdateAnimal(long animalId, [FromBody] Animal newAnimal)
        {
            Animal animal;
            try
            {
                animal = _service.UpdateAnimal(animalId, newAnimal);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(animal);
        }

        [HttpDelete]
        [Route("{animalId}")]
        public IActionResult UpdateAnimal(long animalId)
        {
            try
            {
                _service.DeleteAnimal(animalId);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}