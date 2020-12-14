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
    public class ContactRepository : IRepository<Contact>
    {
        public List<Contact> Get(string connectionString)
        {
            List <Contact> contacts = new List<Contact>();
            // название процедуры
            string sqlExpression = "sp_GetUsersContact";

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
                        //contacts[count].Id = reader.GetInt32(0);
                        //contacts[count].Name = reader.GetString(1);
                        Contact contact = new Contact();
                        contact.Id = reader.GetInt32(0);
                        contact.Name = reader.GetString(1);
                        contacts.Add(contact);
                        count++;
                    }
                }
                reader.Close();
            }
            return contacts;
        }
    }
}
