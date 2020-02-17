using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BestBuyCRUD
{
    public class DapperDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM Departments;").ToList();
        }

        public void InsertDepartment(string newDepartment)
        {
            _connection.Execute("INSERT INTO Departments (Name) VALUES (@departmentName);",
               new { departmentName = newDepartment });
        }

        
        
    }
}
