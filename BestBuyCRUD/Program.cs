﻿using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BestBuyCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = GetAllDepartments();

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
            }
        }
    }
}
