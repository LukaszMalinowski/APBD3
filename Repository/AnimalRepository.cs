using System.Collections.Generic;
using cwiczenia3_zen_s19743.Model;

namespace cwiczenia3_zen_s19743.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        public List<Animal> GetSortedAnimals(string orderBy)
        {
            //TODO check if orderBy is supported
            throw new System.NotImplementedException();
        }

        public Animal AddAnimal(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public Animal UpdateAnimal(long animalId, Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAnimal(long animalId)
        {
            throw new System.NotImplementedException();
        }
    }
}