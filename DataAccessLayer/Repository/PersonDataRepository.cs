using Data_Access_Layer.Interfaces;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class PersonDataRepository : IRepository<PersonData>
    {
        public List<PersonData> Get(string connectionString)
        {
            List<PersonData> personsData = new List<PersonData>();
            // название процедуры
            string sqlExpression = "sp_GetPersons";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                int count = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersonData personData = new PersonData();
                        personData.Id = reader.GetInt32(0);
                        personData.FirstName = reader.GetString(1);
                        personData.LastName = reader.GetString(2);
                        personsData.Add(personData);
                        count++;
                    }
                }
                reader.Close();
            }
            return personsData;
        }
    }
}
