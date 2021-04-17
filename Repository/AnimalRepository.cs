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
                    IdAnimal = Convert.ToInt32(dataReader["IdAnimal"].ToString()),
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
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PjatkDb"));
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "SELECT MAX(IdAnimal) AS maxId FROM Animal"
            };

            connection.Open();

            SqlDataReader sqlDataReader = command.ExecuteReader();

            sqlDataReader.Read();
            int maxId = Convert.ToInt32(sqlDataReader["maxId"].ToString());
            sqlDataReader.Close();

            animal.IdAnimal = maxId + 1;

            command.CommandText = "SET IDENTITY_INSERT Animal ON; " +
                                  "INSERT INTO Animal(IdAnimal, Name, Description, Category, Area) VALUES (@idAnimal, @name, @description, @category, @area); " +
                                  "SET IDENTITY_INSERT Animal OFF;";

            command.Parameters.AddWithValue("@idAnimal", animal.IdAnimal);
            command.Parameters.AddWithValue("@name", animal.Name);
            command.Parameters.AddWithValue("@description", animal.Description);
            command.Parameters.AddWithValue("@category", animal.Category);
            command.Parameters.AddWithValue("@area", animal.Area);


            command.ExecuteNonQuery();

            return animal;
        }

        public Animal UpdateAnimal(long animalId, Animal animal)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PjatkDb"));
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText =
                    "UPDATE Animal SET Name = @name, Description = @description, Category = @category, Area = @area WHERE IdAnimal = @idAnimal"
            };

            command.Parameters.AddWithValue("@idAnimal", animalId);
            command.Parameters.AddWithValue("@name", animal.Name);
            command.Parameters.AddWithValue("@description", animal.Description);
            command.Parameters.AddWithValue("@category", animal.Category);
            command.Parameters.AddWithValue("@area", animal.Area);

            connection.Open();
            command.ExecuteNonQuery();

            animal.IdAnimal = animalId;
            return animal;
        }

        public int DeleteAnimal(long animalId)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PjatkDb"));
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "DELETE FROM Animal WHERE IdAnimal = @idAnimal"
            };

            command.Parameters.AddWithValue("@idAnimal", animalId);

            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}