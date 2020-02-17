using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace BestBuyCRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            var repo = new DapperDepartmentRepository(conn);

           // repo.InsertDepartment("Fun New Department");

            var departments = repo.GetAllDepartments();

           /* foreach (var dep in departments)
            {
                Console.WriteLine($"{dep.DepartmentID} : {dep.Name}.");
            }
            */
            var repoProd = new DapperProductRepository(conn);
            //repoProd.CreateProduct("ISZ Album", 6, 7);
            //repoProd.UpdateProduct(942, 60, "Stuff");
            //repoProd.UpdateProduct(943, 11, "Blah");
            //repoProd.UpdateProduct(944, 2, "Knick-Knacks");
            //repoProd.UpdateProduct(945, 100, "Fingernails");
            //repoProd.UpdateProduct(946, 1, "Creepy Dolls");
            repoProd.DeleteProduct(945);

            var products = repoProd.GetAllProducts(conn);
            foreach(var prod in products)
            {
                Console.WriteLine($"{prod.Name}: ${prod.Price}");
            }
            /* var departments = GetAllDepartments();

             foreach (var dept in departments)
             {
                 Console.WriteLine(dept);
             }
         }

         static IEnumerable GetAllDepartments()
         {
             MySqlConnection conn = new MySqlConnection();
             conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

             MySqlCommand cmd = conn.CreateCommand();
             cmd.CommandText = "SELECT Name FROM Departments;";

             using (conn)
             {
                 conn.Open();
                 List<string> allDepartments = new List<string>();

                 MySqlDataReader reader = cmd.ExecuteReader();

                 while (reader.Read() == true)
                 {
                     var currentDepartment = reader.GetString("Name");
                     allDepartments.Add(currentDepartment);
                 }

                 return allDepartments;
             }

         }
         static void CreateDepartment(string departmentName)
         {
             var connStr = System.IO.File.ReadAllText("ConnectionString.txt");

             using (var conn = new MySqlConnection(connStr))
             {
                 conn.Open();
                 MySqlCommand cmd = conn.CreateCommand();

                 // parameterized query to prevent SQL Injection
                 cmd.CommandText = "INSERT INTO departments (Name) VALUES (@departmentName);";
                 // This method give our above parameter "@departmentName" a value
                 cmd.Parameters.AddWithValue("departmentName", departmentName);
                 cmd.ExecuteNonQuery();
             }*/
        }
    }
}
