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
    public class EmailRepository : IRepository<Email>
    {
        public List<Email> Get(string connectionString)
        {
            List<Email> emails = new List<Email>();
            // название процедуры
            string sqlExpression = "sp_GetUsersEmail";

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
                        //emails[count].Id = reader.GetInt32(0);
                        //emails[count].EmailAddress = reader.GetString(1);
                        Email email = new Email();
                        email.Id = reader.GetInt32(0);
                        email.EmailAddress = reader.GetString(1);
                        emails.Add(email);
                        count++;
                    }
                }
                reader.Close();
            }
            return emails;
        }
    }
}
