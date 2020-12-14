using Data_Access_Layer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccessLayer.Repository
{
    public class PhoneRepository : IRepository<Phone>
    {
        public List<Phone> Get(string connectionString)
        {
            List<Phone> phones = new List<Phone>();
            // название процедуры
            string sqlExpression = "sp_GetUsersPhone";

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
                        //phones[count].Id = reader.GetInt32(0);
                        //phones[count].PhoneNumber = reader.GetString(1);
                        Phone phone = new Phone();
                        phone.Id = reader.GetInt32(0);
                        phone.PhoneNumber = reader.GetString(1);
                        phones.Add(phone);
                        count++;
                    }
                }
                reader.Close();
            }
            return phones;
        }
    }
}
