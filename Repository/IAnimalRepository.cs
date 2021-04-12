using System.Collections.Generic;
using cwiczenia3_zen_s19743.Model;

namespace cwiczenia3_zen_s19743.Repository
{
    public interface IAnimalRepository
    {
        List<Animal> GetSortedAnimals(string orderBy);
        
        Animal AddAnimal(Animal animal);

        Animal UpdateAnimal(long animalId, Animal animal);

        void DeleteAnimal(long animalId);
    }
}