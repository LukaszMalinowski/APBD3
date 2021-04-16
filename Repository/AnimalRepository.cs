using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using cwiczenia3_zen_s19743.Model;
using Microsoft.Extensions.Configuration;

namespace cwiczenia3_zen_s19743.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IConfiguration _configuration;

        public AnimalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Animal> GetSortedAnimals(string orderBy)
        {
            var animals = new List<Animal>();
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PjatkDb"));
            SqlCommand command = new SqlCommand
            {
                Connection = connection, CommandText = "SELECT * FROM Animal ORDER BY " + orderBy 
            };

            command.Parameters.AddWithValue("@orderBy", orderBy);

            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                animals.Add(new Animal
                {
                    IdAnimal = Convert.ToInt64(dataReader["IdAnimal"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Description = dataReader["Description"].ToString(),
                    Category = dataReader["Category"].ToString(),
                    Area = dataReader["Area"].ToString(),
                });
            }

            return animals;
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