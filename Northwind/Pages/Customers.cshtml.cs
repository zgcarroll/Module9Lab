 using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

using System.Data.SqlClient;

 

   public class CustomersModel : PageModel

   {

       public List<Customer> Customers { get; set; }

 

       public void OnGet() // when a Git request comes from the webserver statement gets called

       {

           Customers = new List<Customer>();

           string connectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=P@ssw0rd; ; TrustServerCertificate=True;";

          

           using (SqlConnection connection = new SqlConnection(connectionString))

           {

            connection.Open();

                // sql statement
               string sql = "SELECT CustomerID, CompanyName, ContactName, Country FROM Customers";

               using (SqlCommand command = new SqlCommand(sql, connection))

               {
                    // reader reads through and adds to tables
                   using (SqlDataReader reader = command.ExecuteReader())

                   {

                       while (reader.Read())

                       {

                           Customers.Add(new Customer

                           {

                               CustomerID = reader.GetString(0),

                               CompanyName = reader.GetString(1),

                               ContactName = reader.GetString(2),

                               Country = reader.GetString(3)

                           });

                       }

                   }

               }

           }

       }

   }

 

   public class Customer

   {

       public string CustomerID { get; set; }

       public string CompanyName { get; set; }

       public string ContactName { get; set; }

       public string Country { get; set; }

   }