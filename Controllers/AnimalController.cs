#nullable enable
using System.Collections.Generic;
using cwiczenia3_zen_s19743.Model;
using cwiczenia3_zen_s19743.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia3_zen_s19743.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repository;

        public AnimalController(IAnimalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetSortedAnimals(string? orderBy = "name")
        {
            List<Animal> animals = _repository.GetSortedAnimals(orderBy);
            return Ok(animals);
        }
        
        [HttpPost]
        public IActionResult AddAnimal([FromBody]Animal newAnimal)
        {
            Animal animal = _repository.AddAnimal(newAnimal);
            return Ok(animal);
        }
        
        [HttpPut]
        [Route("{animalId}")]
        public IActionResult UpdateAnimal(long animalId, [FromBody]Animal newAnimal)
        {
            Animal animal = _repository.UpdateAnimal(animalId, newAnimal);
            return Ok(animal);
        }
        
        [HttpDelete]
        [Route("{animalId}")]
        public IActionResult UpdateAnimal(long animalId)
        {
            _repository.DeleteAnimal(animalId);
            return Ok();
        }
    }
}