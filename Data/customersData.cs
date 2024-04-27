using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class customersData
    {
        private string connectionString = "Data Source=LAB1504-11\\SQLEXPRESS; Initial Catalog=NeptunoDB; User Id=Luis; Password=123456";

        public List<Customer> GetPeople()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ListarCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();

                        customer.Name = reader["name"].ToString();
                        customer.Address = reader["address"].ToString();
                        customer.Phone = reader["phone"].ToString();
                        customer.Active = Convert.ToBoolean(reader["active"]);

                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }
    }
}
