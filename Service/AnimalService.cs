﻿using System;
using System.Collections.Generic;
using System.Linq;
using cwiczenia3_zen_s19743.Model;
using cwiczenia3_zen_s19743.Repository;
using Microsoft.AspNetCore.Http;

namespace cwiczenia3_zen_s19743.Service
{
    public class AnimalService : IAnimalService
    {

        private readonly IAnimalRepository _repository;
        private readonly string[] _orderByOptions = {"name", "description", "category", "area"};

        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }

        public List<Animal> GetSortedAnimals(string orderBy)
        {
            if (!_orderByOptions.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            {
                throw new BadHttpRequestException("Field " + orderBy + " doesn't exist.");
            }

            return _repository.GetSortedAnimals(orderBy);
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