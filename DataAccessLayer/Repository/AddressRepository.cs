using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Models;

namespace DataAccessLayer.Repository
{
    public class AddressRepository : IRepository<Address>
    {
        public List<Address> Get(string connectionString)
        {
            List<Address> addresses = new List<Address>();
            // название процедуры
            string sqlExpression = "sp_GetUsers";

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
                        //adresses[count].Id = reader.GetInt32(0);
                        //adresses[count].PersonAddress = reader.GetString(1);
                        Address address = new Address();
                        address.Id = reader.GetInt32(0);
                        address.PersonAddress = reader.GetString(1);
                        addresses.Add(address);
                        count++;
                    }
                }
                reader.Close();
            }
            return addresses;
        }
    }
}
